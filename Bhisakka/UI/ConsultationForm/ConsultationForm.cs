using Bhisakka.DataAccess;
using Bhisakka.Models;
using Bhisakka.Services;
using MaterialComponents;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Bhisakka.UI
{
    public partial class ConsultationForm : LMaterialForm
    {
        private readonly QueueManager queueManager;
        private readonly List<PrescriptionItem> pendingPrescriptionItems;
        private readonly Timer refreshTimer;

        private int? currentAppointmentId;
        private int? currentConsultationId;

        private WaveInEvent waveIn;
        private WaveFileWriter waveWriter;
        private string outputFilePath;
        private DateTime? recordingStartedAt;
        private int recordProgress;

        private SpeechSynthesizer speechSynth;

        public ConsultationForm()
        {
            InitializeComponent();

            queueManager = new QueueManager();
            pendingPrescriptionItems = new List<PrescriptionItem>();

            refreshTimer = new Timer();
            refreshTimer.Interval = 5000;
            refreshTimer.Tick += RefreshTimer_Tick;

            try
            {
                speechSynth = new SpeechSynthesizer();
                speechSynth.SetOutputToDefaultAudioDevice();
            }
            catch
            {
                // No speech engine/voice available: announcements are skipped silently.
                speechSynth = null;
            }
        }

        private void AnnounceNextPatient(QueueEntry entry)
        {
            if (speechSynth == null || entry == null)
            {
                return;
            }

            try
            {
                speechSynth.SpeakAsyncCancelAll();
                speechSynth.SpeakAsync(
                    "Next patient, please proceed to the consultation room. Now serving number " +
                    entry.GetQueueNumber() + ", " + entry.GetPatientName() + ".");
            }
            catch
            {
                // ignore failures
            }
        }

        private void ConsultationForm_Load(object sender, EventArgs e)
        {
            LoadMicrophoneDevices();
            LoadMedicines();
            RefreshCheckInList();
            RefreshQueueList();

            refreshTimer.Start();
        }

        private void ConsultationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentConsultationId != null)
            {
                DialogResult choice = LMaterialDialog.Show(this, "Consultation In Progress",
                    "This consultation has not been saved. If you close now it stays In Progress in " +
                    "the queue and you can resume it later by selecting the patient and clicking Call Next.\r\n\r\n" +
                    "Close without saving?",
                    "Close", "Stay");

                if (choice != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            refreshTimer.Stop();

            try
            {
                if (waveIn != null)
                {
                    waveIn.StopRecording();
                }
            }
            catch { }

            CleanupRecording();

            try
            {
                if (speechSynth != null)
                {
                    speechSynth.SpeakAsyncCancelAll();
                    speechSynth.Dispose();
                    speechSynth = null;
                }
            }
            catch { }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshCheckInList();
            RefreshQueueList();
        }

        private void RefreshCheckInList()
        {
            int selectedIndex = lstCheckIn.SelectedIndex;

            lstCheckIn.Items.Clear();
            foreach (CheckInEntry entry in queueManager.GetScheduledForToday())
            {
                lstCheckIn.Items.Add(entry);
            }

            if (selectedIndex >= 0 && selectedIndex < lstCheckIn.Items.Count)
            {
                lstCheckIn.SelectedIndex = selectedIndex;
            }
        }

        private void RefreshQueueList()
        {
            int selectedIndex = lstQueue.SelectedIndex;

            lstQueue.Items.Clear();
            foreach (QueueEntry entry in queueManager.GetLiveQueue())
            {
                lstQueue.Items.Add(entry);
            }

            if (selectedIndex >= 0 && selectedIndex < lstQueue.Items.Count)
            {
                lstQueue.SelectedIndex = selectedIndex;
            }
        }

        private void LoadMedicines()
        {
            cboMedicine.Items.Clear();
            foreach (MedicineOption option in queueManager.GetActiveMedicines())
            {
                cboMedicine.Items.Add(option);
            }

            if (cboMedicine.Items.Count > 0)
            {
                cboMedicine.SelectedIndex = 0;
            }
        }

        private void BtnCheckIn_Click(object sender, EventArgs e)
        {
            CheckInEntry selected = lstCheckIn.SelectedItem as CheckInEntry;

            if (selected == null)
            {
                LMaterialDialog.Show(this, "No Selection", "Select a patient from today's schedule to check in.");
                return;
            }

            queueManager.CheckIn(selected.GetAppointmentId());
            RefreshCheckInList();
            RefreshQueueList();
        }

        private void BtnCallNext_Click(object sender, EventArgs e)
        {
            if (currentConsultationId != null)
            {
                LMaterialDialog.Show(this, "Consultation In Progress", "Save or complete the current consultation before calling the next patient.");
                return;
            }

            QueueEntry selected = lstQueue.SelectedItem as QueueEntry;

            if (selected == null)
            {
                LMaterialDialog.Show(this, "No Selection", "Select a waiting patient from the live queue.");
                return;
            }

            int doctorId = GlobalSession.GetCurrentUser().GetUserID();

            int consultationId = queueManager.CallNext(selected.GetAppointmentId(), selected.GetPatientId(), doctorId, 0);

            currentAppointmentId = selected.GetAppointmentId();
            currentConsultationId = consultationId;

            lmtPatientName.Text = selected.GetPatientName();
            lmtConsultationID.Text = consultationId.ToString();

            txtDiagnosis.Text = string.Empty;
            rtxtNotes.Text = string.Empty;
            numFee.Value = 0;
            pendingPrescriptionItems.Clear();
            lstPrescriptionItems.Items.Clear();

            RefreshQueueList();

            AnnounceNextPatient(selected);
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            MedicineOption selected = cboMedicine.SelectedItem as MedicineOption;

            if (selected == null)
            {
                LMaterialDialog.Show(this, "No Medicine Selected", "Choose a medicine to prescribe.");
                return;
            }

            PrescriptionItem item = new PrescriptionItem(
                selected.GetMedicineId(),
                selected.GetName(),
                (int)numQuantity.Value,
                txtDosage.Text.Trim());

            pendingPrescriptionItems.Add(item);
            lstPrescriptionItems.Items.Add(item);
            txtDosage.Text = string.Empty;
        }

        private void BtnSaveConsultation_Click(object sender, EventArgs e)
        {
            if (currentConsultationId == null || currentAppointmentId == null)
            {
                LMaterialDialog.Show(this, "No Active Consultation", "Call a patient from the queue before saving.");
                return;
            }

            if (waveIn != null)
            {
                LMaterialDialog.Show(this, "Recording In Progress", "Stop the audio recording before saving the consultation.");
                return;
            }

            queueManager.CompleteConsultation(
                currentConsultationId.Value,
                currentAppointmentId.Value,
                txtDiagnosis.Text.Trim(),
                rtxtNotes.Text.Trim(),
                numFee.Value);

            if (pendingPrescriptionItems.Count > 0)
            {
                int prescriptionId = queueManager.CreatePrescription(currentConsultationId.Value);

                foreach (PrescriptionItem item in pendingPrescriptionItems)
                {
                    queueManager.AddPrescriptionItem(prescriptionId, item.GetMedicineId(), item.GetQuantity(), item.GetDosageInstructions());
                }
            }

            if (lmtSave.Enabled && !string.IsNullOrEmpty(outputFilePath) && File.Exists(outputFilePath))
            {
                SaveRecordingToDatabase();
            }

            LMaterialDialog.Show(this, "Consultation Saved", "The consultation has been completed and saved.");

            currentAppointmentId = null;
            currentConsultationId = null;

            lmtPatientName.Text = string.Empty;
            lmtConsultationID.Text = string.Empty;
            txtDiagnosis.Text = string.Empty;
            rtxtNotes.Text = string.Empty;
            numFee.Value = 0;
            pendingPrescriptionItems.Clear();
            lstPrescriptionItems.Items.Clear();

            RefreshQueueList();
        }

        // ---------------------------------------------------------------
        // Audio recording (Issue #2 — liability auditing)
        // ---------------------------------------------------------------

        private void LoadMicrophoneDevices()
        {
            comboMicrophones.Items.Clear();

            try
            {
                for (int i = 0; i < WaveIn.DeviceCount; i++)
                {
                    var caps = WaveIn.GetCapabilities(i);
                    comboMicrophones.Items.Add(i + ": " + caps.ProductName);
                }

                if (comboMicrophones.Items.Count > 0)
                {
                    comboMicrophones.SelectedIndex = 0;
                }
                else
                {
                    comboMicrophones.Items.Add("No recording devices found");
                    comboMicrophones.SelectedIndex = 0;
                    btnRecord.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                LMaterialDialog.Show(this, "Audio Error", "Error enumerating audio devices: " + ex.Message);
                btnRecord.Enabled = false;
            }
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            if (currentConsultationId == null)
            {
                LMaterialDialog.Show(this, "No Active Consultation", "Call a patient from the queue before recording.");
                return;
            }

            if (comboMicrophones.SelectedIndex < 0)
            {
                LMaterialDialog.Show(this, "No Device", "Select a microphone device first.");
                return;
            }

            try
            {
                int deviceIndex = ParseSelectedDeviceIndex(comboMicrophones.SelectedItem.ToString());

                waveIn = new WaveInEvent();
                waveIn.DeviceNumber = deviceIndex;
                waveIn.WaveFormat = new WaveFormat(44100, 1);

                outputFilePath = Path.Combine(Application.StartupPath, "record_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".wav");
                waveWriter = new WaveFileWriter(outputFilePath, waveIn.WaveFormat);

                waveIn.DataAvailable += OnDataAvailable;
                waveIn.RecordingStopped += OnRecordingStopped;

                waveIn.StartRecording();

                btnRecord.Enabled = false;
                btnStop.Enabled = true;
                lmtSave.Enabled = false;
                lmtRecordStatus.Text = "Recording...";
                recordingStartedAt = DateTime.Now;
                recordProgress = 0;
            }
            catch (Exception ex)
            {
                LMaterialDialog.Show(this, "Recording Error", "Failed to start recording: " + ex.Message);
                CleanupRecording();
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveIn != null)
                {
                    waveIn.StopRecording();
                }
            }
            catch (Exception ex)
            {
                LMaterialDialog.Show(this, "Stop Error", "Error stopping recording: " + ex.Message);
                CleanupRecording();
            }
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            try
            {
                waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
                waveWriter.Flush();

                recordProgress = (recordProgress + (e.BytesRecorded / 4048)) % 101;
                int percent = recordProgress;

                this.BeginInvoke(new Action(() =>
                {
                    lmtPgBar.Value = percent;
                }));
            }
            catch
            {
                // ignore transient write errors while recording
            }
        }

        private void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            CleanupRecording();

            this.Invoke(new Action(() =>
            {
                btnRecord.Enabled = true;
                btnStop.Enabled = false;
                lmtSave.Enabled = true;
                lmtPgBar.Value = 0;
                lmtRecordStatus.Text = "Stopped. Ready to save.";
            }));

            if (e.Exception != null)
            {
                LMaterialDialog.Show(this, "Recording Error", "Recording stopped due to an error: " + e.Exception.Message);
            }
        }

        private void CleanupRecording()
        {
            try
            {
                if (waveIn != null)
                {
                    waveIn.DataAvailable -= OnDataAvailable;
                    waveIn.RecordingStopped -= OnRecordingStopped;
                    waveIn.Dispose();
                    waveIn = null;
                }
            }
            catch { }

            try
            {
                if (waveWriter != null)
                {
                    waveWriter.Dispose();
                    waveWriter = null;
                }
            }
            catch { }
        }

        private int ParseSelectedDeviceIndex(string itemText)
        {
            if (string.IsNullOrEmpty(itemText))
            {
                return 0;
            }

            string[] parts = itemText.Split(':');
            int index;

            if (int.TryParse(parts[0], out index))
            {
                return index;
            }

            return 0;
        }

        private void LmtSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(outputFilePath) || !File.Exists(outputFilePath))
            {
                LMaterialDialog.Show(this, "Save", "No recording available to save.");
                return;
            }

            if (currentConsultationId == null)
            {
                LMaterialDialog.Show(this, "No Active Consultation", "The consultation this recording belongs to is no longer active.");
                return;
            }

            if (SaveRecordingToDatabase())
            {
                LMaterialDialog.Show(this, "Saved", "Recording saved to database.");
            }
        }

        private bool SaveRecordingToDatabase()
        {
            if (currentConsultationId == null || string.IsNullOrEmpty(outputFilePath) || !File.Exists(outputFilePath))
            {
                return false;
            }

            double durationSeconds = 0;

            try
            {
                using (var reader = new WaveFileReader(outputFilePath))
                {
                    durationSeconds = reader.TotalTime.TotalSeconds;
                }
            }
            catch
            {
                // duration stays 0 if it can't be read
            }

            DateTime startedAt = recordingStartedAt ?? File.GetCreationTime(outputFilePath);

            try
            {
                AudioLogs audioLog = new AudioLogs(currentConsultationId.Value, outputFilePath, startedAt, (int)durationSeconds);

                AudioLogRepository repository = new AudioLogRepository();
                repository.InsertAudioLog(audioLog);

                lmtSave.Enabled = false;
                return true;
            }
            catch (Exception ex)
            {
                LMaterialDialog.Show(this, "Save Error", "Database save failed: " + ex.Message);
                return false;
            }
        }
    }
}

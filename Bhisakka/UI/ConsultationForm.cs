using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bhisakka;
using System.IO;
using NAudio.Wave;

namespace Bhisakka.UI
{
    public partial class ConsultationForm : MaterialComponents.LMaterialForm
    {
        public string FormName { get; set; }
        public string FormDescription { get; set; } = "Consulation Workspace";
        public string ConsultantName { get; set; }
        public string ConsultantSpecialty { get; set; }

        // Microphone UI + recording fields
        //private MaterialComponents.LMaterialComboBox comboMicrophones;
        //private MaterialComponents.LMaterialButton btnRecord;
        //private MaterialComponents.LMaterialButton btnStop;
        private WaveInEvent waveIn;
        private WaveFileWriter waveWriter;
        private string outputFilePath;
        // Volume level update throttle
        private DateTime _lastLevelUpdate = DateTime.MinValue;
        private readonly int _levelUpdateIntervalMs = 50; // update progress bar at most ~20Hz


        public ConsultationForm()
        {
            InitializeComponent();
            InitializeMicrophoneControls();
        }

        private void ConsultationForm_Load(object sender, EventArgs e)
        {
            this.Text = FormDescription;
            LoadMicrophoneDevices();
        }

        private void lMaterialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeMicrophoneControls()
        {
            // ComboBox to list devices
            //comboMicrophones = new MaterialComponents.LMaterialComboBox
            //{
            //    DropDownStyle = ComboBoxStyle.DropDownList,
            //    Location = new Point(350, 48),
            //    Width = 360
            //};
            //this.Controls.Add(comboMicrophones);

            //// Record button
            //btnRecord = new MaterialComponents.LMaterialButton
            //{
            //    Text = "Record",
            //    Location = new Point(comboMicrophones.Right + 8, comboMicrophones.Top),
            //    AutoSize = true
            //};
            //btnRecord.Click += BtnRecord_Click;
            //this.Controls.Add(btnRecord);

            //// Stop button
            //btnStop = new  MaterialComponents.LMaterialButton
            //{
            //    Text = "Stop",
            //    Location = new Point(btnRecord.Right + 8, comboMicrophones.Top),
            //    AutoSize = true,
            //    Enabled = false
            //};
            //btnStop.Click += BtnStop_Click;
            //this.Controls.Add(btnStop);
        }

        private void LoadMicrophoneDevices()
        {
            comboMicrophones.Items.Clear();

            try
            {
                for (int i = 0; i < WaveIn.DeviceCount; i++)
                {
                    var caps = WaveIn.GetCapabilities(i);
                    comboMicrophones.Items.Add($"{i}: {caps.ProductName}");
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
                MessageBox.Show($"Error enumerating audio devices: {ex.Message}", "Audio Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMicrophones.Items.Add("Error enumerating devices");
                comboMicrophones.SelectedIndex = 0;
                btnRecord.Enabled = false;
            }
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            if (comboMicrophones.SelectedIndex < 0)
            {
                MessageBox.Show("Select a microphone device first.", "No Device", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int deviceIndex = ParseSelectedDeviceIndex(comboMicrophones.SelectedItem?.ToString());
                waveIn = new WaveInEvent
                {
                    DeviceNumber = deviceIndex,
                    WaveFormat = new WaveFormat(44100, 1) // 44.1kHz mono
                };

                outputFilePath = Path.Combine(Application.StartupPath, $"record_{DateTime.Now:yyyyMMdd_HHmmss}.wav");
                waveWriter = new WaveFileWriter(outputFilePath, waveIn.WaveFormat);

                waveIn.DataAvailable += OnDataAvailable;
                waveIn.RecordingStopped += OnRecordingStopped;

                waveIn.StartRecording();

                btnRecord.Enabled = false;
                btnStop.Enabled = true;
                MessageBox.Show($"Recording started. File will be saved to:\n{outputFilePath}", "Recording", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lmtRecordStatus.Text = "Recording...";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start recording: {ex.Message}", "Recording Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanupRecording();
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            StopRecording();
            lmtRecordStatus.Text += "Stopped.";
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    lmtPgBar.Value = Math.Min(lmtPgBar.Value + e.BytesRecorded/4048, lmtPgBar.Maximum);
                }));
                waveWriter?.Write(e.Buffer, 0, e.BytesRecorded);
                waveWriter?.Flush();
                // Compute peak level for 16-bit PCM and update progress bar as percentage (0..100)
                // Throttle UI updates to _levelUpdateIntervalMs to avoid flooding the UI thread.
                if ((DateTime.UtcNow - _lastLevelUpdate).TotalMilliseconds < _levelUpdateIntervalMs)
                    return;

                _lastLevelUpdate = DateTime.UtcNow;

                int bytesPerSample = waveIn.WaveFormat.BitsPerSample / 8;
                int maxAbsolute = 0;

                if (bytesPerSample == 2) // 16-bit PCM
                {
                    for (int index = 0; index < e.BytesRecorded; index += 2)
                    {
                        if (index + 1 >= e.BytesRecorded)
                            break;
                        short sample = (short)(e.Buffer[index] | (e.Buffer[index + 1] << 8));
                        int abs = Math.Abs(sample);
                        if (abs > maxAbsolute) maxAbsolute = abs;
                    }

                    int percent = (int)(maxAbsolute / 32767.0 * 100.0);
                    percent = Math.Min(Math.Max(percent, 0), 100);

                    // Update UI safely
                    try
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            try
                            {
                                lmtPgBar.Value = percent;
                            }
                            catch
                            {
                                // ignore if progress bar not present or range mismatch
                            }
                        }));
                    }
                    catch
                    {
                        // BeginInvoke can throw if form is closing; ignore
                    }
                }
                else
                {
                    // Other bit depths: fallback to zero or implement conversions if needed
                }
            }
            catch
            {
                // swallow write/errors to keep recording stable
            }


        }
            
        

        private void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            CleanupRecording();

            if (e.Exception != null)
            {
                MessageBox.Show($"Recording stopped due to an error: {e.Exception.Message}", "Recording Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Recording saved to:\n{outputFilePath}", "Recording Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Invoke(new Action(() =>
            {
                btnRecord.Enabled = true;
                btnStop.Enabled = false;
            }));
        }

        private void StopRecording()
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
                MessageBox.Show($"Error stopping recording: {ex.Message}", "Stop Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CleanupRecording();
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
            catch { /* ignore */ }

            try
            {
                waveWriter?.Dispose();
                waveWriter = null;
            }
            catch { /* ignore */ }
        }

        private int ParseSelectedDeviceIndex(string itemText)
        {
            if (string.IsNullOrEmpty(itemText))
                return 0;

            var parts = itemText.Split(':');
            if (int.TryParse(parts[0], out int idx))
                return idx;

            return 0;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Ensure recording is stopped and resources freed
            try
            {
                if (waveIn != null)
                {
                    waveIn.StopRecording();
                }
            }
            catch { }

            CleanupRecording();
            base.OnFormClosing(e);          
        }

        private void btnRecord_Click_1(object sender, EventArgs e)
        {

        }
    }
}

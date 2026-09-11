using Bhisakka.DataAccess;
using Bhisakka.Models;
using MaterialComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bhisakka.UI.PatientHistory
{
    public partial class ConsultationHistoryForm : LMaterialForm
    {
        private readonly ConsultationHistoryRepository historyRepository;

        public ConsultationHistoryForm()
        {
            InitializeComponent();

            historyRepository = new ConsultationHistoryRepository();

            SetupResultsColumns();
            SetupHistoryColumns();
        }

        private void SetupResultsColumns()
        {
            dgvResults.Columns.Clear();
            dgvResults.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colPatientId = new DataGridViewTextBoxColumn();
            colPatientId.Name = "colPatientId";
            colPatientId.HeaderText = "Patient ID";
            colPatientId.Visible = false;

            DataGridViewTextBoxColumn colFullName = new DataGridViewTextBoxColumn();
            colFullName.Name = "colFullName";
            colFullName.HeaderText = "Patient Name";
            colFullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn colDob = new DataGridViewTextBoxColumn();
            colDob.Name = "colDob";
            colDob.HeaderText = "Date of Birth";
            colDob.Width = 160;

            dgvResults.Columns.Add(colPatientId);
            dgvResults.Columns.Add(colFullName);
            dgvResults.Columns.Add(colDob);
        }

        private void SetupHistoryColumns()
        {
            dgvHistory.Columns.Clear();
            dgvHistory.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colAppointmentDate = new DataGridViewTextBoxColumn();
            colAppointmentDate.Name = "colAppointmentDate";
            colAppointmentDate.HeaderText = "Appointment Date";
            colAppointmentDate.Width = 130;

            DataGridViewTextBoxColumn colStartedAt = new DataGridViewTextBoxColumn();
            colStartedAt.Name = "colStartedAt";
            colStartedAt.HeaderText = "Started At";
            colStartedAt.Width = 140;

            DataGridViewTextBoxColumn colDiagnosis = new DataGridViewTextBoxColumn();
            colDiagnosis.Name = "colDiagnosis";
            colDiagnosis.HeaderText = "Diagnosis";
            colDiagnosis.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDiagnosis.FillWeight = 30;

            DataGridViewTextBoxColumn colNotes = new DataGridViewTextBoxColumn();
            colNotes.Name = "colNotes";
            colNotes.HeaderText = "Notes";
            colNotes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNotes.FillWeight = 40;

            DataGridViewTextBoxColumn colFee = new DataGridViewTextBoxColumn();
            colFee.Name = "colFee";
            colFee.HeaderText = "Fee (LKR)";
            colFee.Width = 100;
            colFee.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colMedicines = new DataGridViewTextBoxColumn();
            colMedicines.Name = "colMedicines";
            colMedicines.HeaderText = "Medicines Prescribed";
            colMedicines.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMedicines.FillWeight = 30;

            dgvHistory.Columns.Add(colAppointmentDate);
            dgvHistory.Columns.Add(colStartedAt);
            dgvHistory.Columns.Add(colDiagnosis);
            dgvHistory.Columns.Add(colNotes);
            dgvHistory.Columns.Add(colFee);
            dgvHistory.Columns.Add(colMedicines);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string namePrefix = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(namePrefix))
            {
                LMaterialDialog.Show(this, "Search", "Enter a first or last name to search for a patient.");
                return;
            }

            dgvHistory.Rows.Clear();
            dgvResults.Rows.Clear();

            List<PatientSearchResult> results;

            try
            {
                results = historyRepository.SearchPatients(namePrefix);
            }
            catch (Exception ex)
            {
                LMaterialDialog.Show(this, "Search Error", "Failed to search patients: " + ex.Message);
                return;
            }

            if (results.Count == 0)
            {
                LMaterialDialog.Show(this, "No Results", "No patients matched that name.");
                return;
            }

            foreach (PatientSearchResult result in results)
            {
                int rowIndex = dgvResults.Rows.Add();
                DataGridViewRow row = dgvResults.Rows[rowIndex];
                row.Cells["colPatientId"].Value = result.GetPatientId();
                row.Cells["colFullName"].Value = result.GetFullName();
                row.Cells["colDob"].Value = result.GetDateOfBirth().ToString("yyyy-MM-dd");
            }
        }

        private void DgvResults_SelectionChanged(object sender, EventArgs e)
        {
            dgvHistory.Rows.Clear();

            if (dgvResults.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dgvResults.SelectedRows[0];
            object patientIdValue = selectedRow.Cells["colPatientId"].Value;

            if (patientIdValue == null)
            {
                return;
            }

            int patientId = Convert.ToInt32(patientIdValue);

            List<MedicalRecord> history;

            try
            {
                history = historyRepository.GetHistory(patientId);
            }
            catch (Exception ex)
            {
                LMaterialDialog.Show(this, "History Error", "Failed to load consultation history: " + ex.Message);
                return;
            }

            foreach (MedicalRecord record in history)
            {
                ConsultationNote note = record.GetConsultationNote();

                int rowIndex = dgvHistory.Rows.Add();
                DataGridViewRow row = dgvHistory.Rows[rowIndex];
                row.Cells["colAppointmentDate"].Value = record.GetAppointmentDate().ToString("yyyy-MM-dd");
                row.Cells["colStartedAt"].Value = record.GetStartedAt().ToString("yyyy-MM-dd HH:mm");
                row.Cells["colDiagnosis"].Value = note.GetDiagnosis();
                row.Cells["colNotes"].Value = note.GetNotes();
                row.Cells["colFee"].Value = record.GetConsultationFee().ToString("0.00");
                row.Cells["colMedicines"].Value = record.GetMedicinesPrescribed();
            }
        }
    }
}

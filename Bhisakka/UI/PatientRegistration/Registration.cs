using Bhisakka.DataAccess;
using Bhisakka.Models;
using MaterialComponents;
using System;
using System.Windows.Forms;

namespace Bhisakka.UI.PatientRegistration
{
    public partial class Registration : LMaterialForm
    {
        public Registration()
        {
            InitializeComponent();

            dtpDob.InnerDateTimePicker.MinDate = DateTime.Today.AddYears(-120);
            dtpDob.InnerDateTimePicker.MaxDate = DateTime.Today;
            dtpDob.Value = DateTime.Today;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string contact = txtContact.Text.Trim();

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(contact))
            {
                LMaterialDialog.Show(this, "Missing Information",
                    "Please fill in the first name, last name and contact number.");
                return;
            }

            string gender;
            if (rdoMale.Checked)
            {
                gender = "Male";
            }
            else if (rdoFemale.Checked)
            {
                gender = "Female";
            }
            else if (rdoOther.Checked)
            {
                gender = "Other";
            }
            else
            {
                gender = "";
            }

            if (gender.Length == 0)
            {
                LMaterialDialog.Show(this, "No Gender Selected", "Please select a gender.");
                return;
            }

            DateTime dateOfBirth = dtpDob.Value.Date;
            if (dateOfBirth > DateTime.Today)
            {
                LMaterialDialog.Show(this, "Invalid Date of Birth", "Date of birth cannot be in the future.");
                return;
            }

            Patient patient = new Patient(
                0,
                firstName,
                lastName,
                dateOfBirth,
                gender,
                contact,
                txtAddress.Text.Trim());

            try
            {
                PatientRepository repository = new PatientRepository();
                repository.InsertPatient(patient);
            }
            catch (Exception ex)
            {
                LMaterialDialog.Show(this, "Registration Failed",
                    "The patient could not be registered: " + ex.Message);
                return;
            }

            LMaterialDialog.Show(this, "Registration Successful",
                "Patient " + patient.GetFirstName() + " " + patient.GetLastName() + " has been registered.");

            ClearForm();
        }

        private void ClearForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            rdoOther.Checked = false;
            dtpDob.Value = DateTime.Today;
            txtFirstName.FocusInner();
        }
    }
}

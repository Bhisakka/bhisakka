using Bhisakka.DataAccess;
using Bhisakka.Models;
using MaterialComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bhisakka.UI.PatientRegistration
{
    public partial class Registration : LMaterialForm
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void lMaterialButton1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtAge.Text, out int age)) 
            {
                LMaterialDialog.Show(this, "Invalid Age", "Age must be a number!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text))
            {
                //MessageBox.Show("Please fill in all required fields!");
                LMaterialDialog.Show(this, "No Empty fields allowed", "Please fill in all required fields!");

                
                return;
            }

            string gender = rdoMale.Checked ? "Male" : (rdoFemale.Checked ? "Female" : "");

            if (string.IsNullOrEmpty(gender))
            {
                LMaterialDialog.Show(this, "No Gender selected", "Please select a gender!");
                return;
            }

            Patient patient = new Patient(
                0,
                txtFirstName.Text.Trim(),
                txtLastName.Text.Trim(),
                DateTime.Today.AddYears(-age),
                gender,
                txtContact.Text.Trim(),
                txtAddress.Text.Trim()
            );

            var repository = new PatientRepository();
            repository.InsertPatient(patient);

            LMaterialDialog.Show(this, "Registration Successful", "Patient " + patient.GetFirstName() + " " + patient.GetLastName() + " has been registered.");
        }

        private void lMaterialTableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


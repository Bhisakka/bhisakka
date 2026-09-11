using Bhisakka.Models;
using Bhisakka.Util;
using MaterialComponents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bhisakka.UI.Dashboard
{
    public partial class Dashboard : LMaterialForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Bhisakka.UI.Ambiance.MediaControllerControl mediaController = new Bhisakka.UI.Ambiance.MediaControllerControl();
            mediaController.Dock = DockStyle.Fill;
            pnlMediaControllerHost.Controls.Add(mediaController);

            User currentUser = GlobalSession.GetCurrentUser();

            if (currentUser == null)
            {
                return;
            }

            // Single-doctor clinic: show the role, not the practitioner's name.
            lblWelcome.Text = "Welcome";
            lblRole.Text = "Signed in as " + currentUser.GetUserRole().GetRoleName();

            BuildNavButtons(currentUser.GetUserRole().GetRoleName());
        }

        private void BuildNavButtons(string roleName)
        {
            pnlNavButtons.Controls.Clear();

            if (roleName == "Doctor")
            {
                AddNavButton("Consultation Workspace", () => WindowManager.GetInstance().Show<ConsultationForm>());
                AddNavButton("Patient History", () => WindowManager.GetInstance().Show<PatientHistory.ConsultationHistoryForm>());
                AddNavButton("Schedule Configuration", () => WindowManager.GetInstance().Show<Scheduling.ScheduleConfigForm>());
                AddNavButton("Pharmacy Inventory", () => WindowManager.GetInstance().Show<Pharmacy.InventoryForm>());
            }
            else if (roleName == "Receptionist")
            {
                AddNavButton("Register Patient", () => WindowManager.GetInstance().Show<PatientRegistration.Registration>());
                AddNavButton("Book Appointment", () => WindowManager.GetInstance().Show<Booking.BookAppointmentForm>());
                AddNavButton("Patient History", () => WindowManager.GetInstance().Show<PatientHistory.ConsultationHistoryForm>());
                AddNavButton("Billing", () => WindowManager.GetInstance().Show<Billing.InvoiceGenerationForm>());
            }
            else if (roleName == "Pharmacist")
            {
                AddNavButton("Pharmacy Inventory", () => WindowManager.GetInstance().Show<Pharmacy.InventoryForm>());
                AddNavButton("Billing", () => WindowManager.GetInstance().Show<Billing.InvoiceGenerationForm>());
            }
        }

        private void AddNavButton(string text, Action onClick)
        {
            LMaterialButton button = new LMaterialButton();
            button.Text = text;
            button.Variant = LMaterialButtonVariant.Tonal;
            button.Size = new Size(264, 44);
            button.Margin = new Padding(4, 4, 4, 6);
            button.Click += (sender, e) => onClick();

            pnlNavButtons.Controls.Add(button);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            GlobalSession.Logout();
            WindowManager.GetInstance().Show<AuthN.SignIn>();
            this.Close();
        }
    }
}

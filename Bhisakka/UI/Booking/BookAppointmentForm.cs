using Bhisakka.DataAccess;
using Bhisakka.Models;
using Bhisakka.Services;
using MaterialComponents;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bhisakka.UI.Booking
{
    public partial class BookAppointmentForm : LMaterialForm
    {
        private AppointmentRepository appointmentRepository;
        private ScheduleManager scheduleManager;
        private int bookingWindowDays;
        private bool isRefreshingDate;

        public BookAppointmentForm()
        {
            InitializeComponent();

            appointmentRepository = new AppointmentRepository();
            scheduleManager = new ScheduleManager();
            bookingWindowDays = scheduleManager.GetBookingWindowDays();
            isRefreshingDate = false;

            SetupDateWindow();
            LoadPatients();
            RefreshSlots();
        }

        private void SetupDateWindow()
        {
            DateTimePicker innerPicker = dtpDate.InnerDateTimePicker;
            innerPicker.MinDate = DateTime.Today;
            innerPicker.MaxDate = DateTime.Today.AddDays(bookingWindowDays);

            dtpDate.Value = DateTime.Today;
        }

        private void LoadPatients()
        {
            cboPatient.Items.Clear();

            List<PatientOption> patients = appointmentRepository.GetAllPatients();

            for (int i = 0; i < patients.Count; i++)
            {
                cboPatient.Items.Add(patients[i]);
            }

            if (cboPatient.Items.Count > 0)
            {
                cboPatient.SelectedIndex = 0;
            }
        }

        private void RefreshSlots()
        {
            cboSlot.Items.Clear();

            DateTime pickedDate = dtpDate.Value.Date;
            List<TimeSlot> slots = scheduleManager.GetAvailableSlots(pickedDate);

            if (slots.Count == 0)
            {
                cboSlot.Items.Add("No slots available");
                cboSlot.SelectedIndex = 0;
                btnBook.Enabled = false;
                return;
            }

            for (int i = 0; i < slots.Count; i++)
            {
                cboSlot.Items.Add(slots[i]);
            }

            cboSlot.SelectedIndex = 0;
            btnBook.Enabled = true;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (isRefreshingDate)
            {
                return;
            }

            DateTime minDate = DateTime.Today;
            DateTime maxDate = DateTime.Today.AddDays(bookingWindowDays);

            if (dtpDate.Value.Date < minDate || dtpDate.Value.Date > maxDate)
            {
                isRefreshingDate = true;
                dtpDate.Value = DateTime.Today;
                isRefreshingDate = false;

                LMaterialDialog.Show(this, "Outside Booking Window",
                    "Appointments can only be booked between today and " + maxDate.ToShortDateString() + ".");
            }

            RefreshSlots();
        }

        private void btnBook_Click_1(object sender, EventArgs e)
        {
            PatientOption selectedPatient = cboPatient.SelectedItem as PatientOption;
            if (selectedPatient == null)
            {
                LMaterialDialog.Show(this, "No Patient Selected", "Please select a patient first.");
                return;
            }

            TimeSlot selectedSlot = cboSlot.SelectedItem as TimeSlot;
            if (selectedSlot == null)
            {
                LMaterialDialog.Show(this, "No Slot Selected", "Please select an available time slot first.");
                return;
            }

            User currentUser = GlobalSession.GetCurrentUser();
            if (currentUser == null)
            {
                LMaterialDialog.Show(this, "Not Signed In", "You must be signed in to book an appointment.");
                return;
            }

            Appointment appointment = new Appointment(
                0,
                selectedPatient.GetPatientId(),
                dtpDate.Value.Date,
                selectedSlot.GetStartTime(),
                selectedSlot.GetEndTime(),
                currentUser.GetUserID());

            try
            {
                appointmentRepository.InsertAppointment(appointment);

                LMaterialDialog.Show(this, "Appointment Booked",
                    "The appointment for " + selectedPatient.GetFullName() + " on " +
                    dtpDate.Value.ToShortDateString() + " at " + selectedSlot.ToString() + " has been booked.");

                RefreshSlots();
            }
            catch (PostgresException ex)
            {
                if (string.Equals(ex.SqlState, "23505", StringComparison.Ordinal))
                {
                    LMaterialDialog.Show(this, "Slot Taken", "That time slot was just booked by someone else. Please pick another.");
                    RefreshSlots();
                }
                else
                {
                    LMaterialDialog.Show(this, "Booking Failed", "An error occurred while booking the appointment: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                LMaterialDialog.Show(this, "Booking Failed", "An unexpected error occurred while booking the appointment: " + ex.Message);
            }
        }
    }
}

using System;

namespace Bhisakka.Models
{
    internal class Consultation
    {
        private int consultationId;
        private int appointmentId;
        private int patientId;
        private int doctorId;
        private string diagnosis;
        private string notes;
        private decimal consultationFee;

        public Consultation(int appointmentId, int patientId, int doctorId, string diagnosis, string notes, decimal consultationFee)
        {
            this.appointmentId = appointmentId;
            this.patientId = patientId;
            this.doctorId = doctorId;
            this.diagnosis = diagnosis;
            this.notes = notes;
            this.consultationFee = consultationFee;
        }

        public int GetConsultationId()
        {
            return consultationId;
        }

        public void SetConsultationId(int value)
        {
            consultationId = value;
        }

        public int GetAppointmentId()
        {
            return appointmentId;
        }

        public int GetPatientId()
        {
            return patientId;
        }

        public int GetDoctorId()
        {
            return doctorId;
        }

        public string GetDiagnosis()
        {
            return diagnosis;
        }

        public void SetDiagnosis(string value)
        {
            diagnosis = value;
        }

        public string GetNotes()
        {
            return notes;
        }

        public void SetNotes(string value)
        {
            notes = value;
        }

        public decimal GetConsultationFee()
        {
            return consultationFee;
        }

        public void SetConsultationFee(decimal value)
        {
            consultationFee = value;
        }
    }
}

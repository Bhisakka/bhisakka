using System;

namespace Bhisakka.Models
{
    internal class MedicalRecord
    {
        private DateTime appointmentDate;
        private DateTime startedAt;
        private decimal consultationFee;
        private string medicinesPrescribed;
        private ConsultationNote consultationNote;

        public MedicalRecord(DateTime appointmentDate, DateTime startedAt, decimal consultationFee, string medicinesPrescribed, ConsultationNote consultationNote)
        {
            this.appointmentDate = appointmentDate;
            this.startedAt = startedAt;
            this.consultationFee = consultationFee;
            this.medicinesPrescribed = medicinesPrescribed;
            this.consultationNote = consultationNote;
        }

        public DateTime GetAppointmentDate()
        {
            return appointmentDate;
        }

        public void SetAppointmentDate(DateTime value)
        {
            appointmentDate = value;
        }

        public DateTime GetStartedAt()
        {
            return startedAt;
        }

        public void SetStartedAt(DateTime value)
        {
            startedAt = value;
        }

        public decimal GetConsultationFee()
        {
            return consultationFee;
        }

        public void SetConsultationFee(decimal value)
        {
            consultationFee = value;
        }

        public string GetMedicinesPrescribed()
        {
            return medicinesPrescribed;
        }

        public void SetMedicinesPrescribed(string value)
        {
            medicinesPrescribed = value;
        }

        public ConsultationNote GetConsultationNote()
        {
            return consultationNote;
        }

        public void SetConsultationNote(ConsultationNote value)
        {
            consultationNote = value;
        }
    }
}

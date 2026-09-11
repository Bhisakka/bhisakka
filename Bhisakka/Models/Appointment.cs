using System;

namespace Bhisakka.Models
{
    internal class Appointment
    {
        private int appointmentId;
        private int patientId;
        private DateTime appointmentDate;
        private TimeSpan startTime;
        private TimeSpan endTime;
        private int bookedBy;

        public Appointment(int appointmentId, int patientId, DateTime appointmentDate, TimeSpan startTime, TimeSpan endTime, int bookedBy)
        {
            this.appointmentId = appointmentId;
            this.patientId = patientId;
            this.appointmentDate = appointmentDate;
            this.startTime = startTime;
            this.endTime = endTime;
            this.bookedBy = bookedBy;
        }

        public int GetAppointmentId()
        {
            return appointmentId;
        }

        public void SetAppointmentId(int value)
        {
            appointmentId = value;
        }

        public int GetPatientId()
        {
            return patientId;
        }

        public void SetPatientId(int value)
        {
            patientId = value;
        }

        public DateTime GetAppointmentDate()
        {
            return appointmentDate;
        }

        public void SetAppointmentDate(DateTime value)
        {
            appointmentDate = value;
        }

        public TimeSpan GetStartTime()
        {
            return startTime;
        }

        public void SetStartTime(TimeSpan value)
        {
            startTime = value;
        }

        public TimeSpan GetEndTime()
        {
            return endTime;
        }

        public void SetEndTime(TimeSpan value)
        {
            endTime = value;
        }

        public int GetBookedBy()
        {
            return bookedBy;
        }

        public void SetBookedBy(int value)
        {
            bookedBy = value;
        }
    }
}

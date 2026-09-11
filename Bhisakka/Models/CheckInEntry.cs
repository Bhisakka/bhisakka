using System;

namespace Bhisakka.Models
{
    internal class CheckInEntry
    {
        private int appointmentId;
        private string patientName;
        private TimeSpan startTime;

        public CheckInEntry(int appointmentId, string patientName, TimeSpan startTime)
        {
            this.appointmentId = appointmentId;
            this.patientName = patientName;
            this.startTime = startTime;
        }

        public int GetAppointmentId()
        {
            return appointmentId;
        }

        public string GetPatientName()
        {
            return patientName;
        }

        public TimeSpan GetStartTime()
        {
            return startTime;
        }

        public override string ToString()
        {
            return startTime.ToString(@"hh\:mm") + "  " + patientName;
        }
    }
}

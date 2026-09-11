using System;

namespace Bhisakka.Models
{
    internal class QueueEntry
    {
        private int appointmentId;
        private int patientId;
        private int queueNumber;
        private string patientName;
        private TimeSpan startTime;
        private string status;

        public QueueEntry(int appointmentId, int patientId, int queueNumber, string patientName, TimeSpan startTime, string status)
        {
            this.appointmentId = appointmentId;
            this.patientId = patientId;
            this.queueNumber = queueNumber;
            this.patientName = patientName;
            this.startTime = startTime;
            this.status = status;
        }

        public int GetAppointmentId()
        {
            return appointmentId;
        }

        public int GetPatientId()
        {
            return patientId;
        }

        public int GetQueueNumber()
        {
            return queueNumber;
        }

        public string GetPatientName()
        {
            return patientName;
        }

        public TimeSpan GetStartTime()
        {
            return startTime;
        }

        public string GetStatus()
        {
            return status;
        }

        public override string ToString()
        {
            return "#" + queueNumber + "  " + patientName + "  (" + status + ")";
        }
    }
}

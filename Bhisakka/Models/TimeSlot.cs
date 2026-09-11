using System;

namespace Bhisakka.Models
{
    internal class TimeSlot
    {
        private TimeSpan startTime;
        private TimeSpan endTime;

        public TimeSlot(TimeSpan startTime, TimeSpan endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
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

        public override string ToString()
        {
            return startTime.ToString(@"hh\:mm") + " - " + endTime.ToString(@"hh\:mm");
        }
    }
}

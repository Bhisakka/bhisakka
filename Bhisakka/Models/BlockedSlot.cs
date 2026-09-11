using System;

namespace Bhisakka.Models
{
    internal class BlockedSlot
    {
        private int blockedSlotId;
        private DateTime blockDate;
        private TimeSpan startTime;
        private TimeSpan endTime;
        private string reason;
        private int createdBy;

        public BlockedSlot(int blockedSlotId, DateTime blockDate, TimeSpan startTime, TimeSpan endTime, string reason, int createdBy)
        {
            this.blockedSlotId = blockedSlotId;
            this.blockDate = blockDate;
            this.startTime = startTime;
            this.endTime = endTime;
            this.reason = reason;
            this.createdBy = createdBy;
        }

        public int GetBlockedSlotId()
        {
            return blockedSlotId;
        }

        public void SetBlockedSlotId(int value)
        {
            blockedSlotId = value;
        }

        public DateTime GetBlockDate()
        {
            return blockDate;
        }

        public void SetBlockDate(DateTime value)
        {
            blockDate = value;
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

        public string GetReason()
        {
            return reason;
        }

        public void SetReason(string value)
        {
            reason = value;
        }

        public int GetCreatedBy()
        {
            return createdBy;
        }

        public void SetCreatedBy(int value)
        {
            createdBy = value;
        }
    }
}

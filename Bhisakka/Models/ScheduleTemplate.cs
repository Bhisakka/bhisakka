using System;

namespace Bhisakka.Models
{
    internal class ScheduleTemplate
    {
        private int templateId;
        private int dayOfWeek;
        private string blockType;
        private string label;
        private TimeSpan startTime;
        private TimeSpan endTime;
        private int? slotDurationMinutes;
        private bool isActive;

        public ScheduleTemplate(int templateId, int dayOfWeek, string blockType, string label, TimeSpan startTime, TimeSpan endTime, int? slotDurationMinutes, bool isActive)
        {
            this.templateId = templateId;
            this.dayOfWeek = dayOfWeek;
            this.blockType = blockType;
            this.label = label;
            this.startTime = startTime;
            this.endTime = endTime;
            this.slotDurationMinutes = slotDurationMinutes;
            this.isActive = isActive;
        }

        public int GetTemplateId()
        {
            return templateId;
        }

        public void SetTemplateId(int value)
        {
            templateId = value;
        }

        public int GetDayOfWeek()
        {
            return dayOfWeek;
        }

        public void SetDayOfWeek(int value)
        {
            dayOfWeek = value;
        }

        public string GetBlockType()
        {
            return blockType;
        }

        public void SetBlockType(string value)
        {
            blockType = value;
        }

        public string GetLabel()
        {
            return label;
        }

        public void SetLabel(string value)
        {
            label = value;
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

        public int? GetSlotDurationMinutes()
        {
            return slotDurationMinutes;
        }

        public void SetSlotDurationMinutes(int? value)
        {
            slotDurationMinutes = value;
        }

        public bool GetIsActive()
        {
            return isActive;
        }

        public void SetIsActive(bool value)
        {
            isActive = value;
        }
    }
}

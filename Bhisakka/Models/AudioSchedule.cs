using System;

namespace Bhisakka.Models
{
    internal class AudioSchedule
    {
        private int audioScheduleId;
        private string trackName;
        private string filePath;
        private string trackType;
        private TimeSpan? triggerTime;
        private bool isEnabled;

        public AudioSchedule(int audioScheduleId, string trackName, string filePath, string trackType, TimeSpan? triggerTime, bool isEnabled)
        {
            this.audioScheduleId = audioScheduleId;
            this.trackName = trackName;
            this.filePath = filePath;
            this.trackType = trackType;
            this.triggerTime = triggerTime;
            this.isEnabled = isEnabled;
        }

        public int GetAudioScheduleId()
        {
            return audioScheduleId;
        }

        public void SetAudioScheduleId(int value)
        {
            audioScheduleId = value;
        }

        public string GetTrackName()
        {
            return trackName;
        }

        public void SetTrackName(string value)
        {
            trackName = value;
        }

        public string GetFilePath()
        {
            return filePath;
        }

        public void SetFilePath(string value)
        {
            filePath = value;
        }

        public string GetTrackType()
        {
            return trackType;
        }

        public void SetTrackType(string value)
        {
            trackType = value;
        }

        public TimeSpan? GetTriggerTime()
        {
            return triggerTime;
        }

        public void SetTriggerTime(TimeSpan? value)
        {
            triggerTime = value;
        }

        public bool GetIsEnabled()
        {
            return isEnabled;
        }

        public void SetIsEnabled(bool value)
        {
            isEnabled = value;
        }

        public override string ToString()
        {
            return trackName;
        }
    }
}

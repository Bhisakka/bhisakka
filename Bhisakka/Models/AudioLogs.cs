using System;

namespace Bhisakka.Models
{
    internal class AudioLogs
    {
        private int audioLogId;
        private int consultationId;
        private string filePath;
        private DateTime startedAt;
        private int durationSeconds;

        public AudioLogs(int consultationId, string filePath, DateTime startedAt, int durationSeconds)
        {
            this.consultationId = consultationId;
            this.filePath = filePath;
            this.startedAt = startedAt;
            this.durationSeconds = durationSeconds;
        }

        public int GetAudioLogId()
        {
            return audioLogId;
        }

        public void SetAudioLogId(int value)
        {
            audioLogId = value;
        }

        public int GetConsultationId()
        {
            return consultationId;
        }

        public void SetConsultationId(int value)
        {
            consultationId = value;
        }

        public string GetFilePath()
        {
            return filePath;
        }

        public void SetFilePath(string value)
        {
            filePath = value;
        }

        public DateTime GetStartedAt()
        {
            return startedAt;
        }

        public void SetStartedAt(DateTime value)
        {
            startedAt = value;
        }

        public int GetDurationSeconds()
        {
            return durationSeconds;
        }

        public void SetDurationSeconds(int value)
        {
            durationSeconds = value;
        }
    }
}

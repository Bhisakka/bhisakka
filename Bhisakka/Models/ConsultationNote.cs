namespace Bhisakka.Models
{
    internal class ConsultationNote
    {
        private string diagnosis;
        private string notes;

        public ConsultationNote(string diagnosis, string notes)
        {
            this.diagnosis = diagnosis;
            this.notes = notes;
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
    }
}

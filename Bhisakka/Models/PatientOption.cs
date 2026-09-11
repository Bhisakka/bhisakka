namespace Bhisakka.Models
{
    internal class PatientOption
    {
        private int patientId;
        private string fullName;

        public PatientOption(int patientId, string fullName)
        {
            this.patientId = patientId;
            this.fullName = fullName;
        }

        public int GetPatientId()
        {
            return patientId;
        }

        public void SetPatientId(int value)
        {
            patientId = value;
        }

        public string GetFullName()
        {
            return fullName;
        }

        public void SetFullName(string value)
        {
            fullName = value;
        }

        public override string ToString()
        {
            return fullName;
        }
    }
}

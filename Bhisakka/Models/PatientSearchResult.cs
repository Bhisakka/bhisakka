using System;

namespace Bhisakka.Models
{
    internal class PatientSearchResult
    {
        private int patientId;
        private string fullName;
        private DateTime dateOfBirth;

        public PatientSearchResult(int patientId, string fullName, DateTime dateOfBirth)
        {
            this.patientId = patientId;
            this.fullName = fullName;
            this.dateOfBirth = dateOfBirth;
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

        public DateTime GetDateOfBirth()
        {
            return dateOfBirth;
        }

        public void SetDateOfBirth(DateTime value)
        {
            dateOfBirth = value;
        }

        public override string ToString()
        {
            return fullName;
        }
    }
}

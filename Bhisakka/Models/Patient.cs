using System;

namespace Bhisakka.Models
{
    internal class Patient
    {
        private int patientId;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string gender;
        private string contactNumber;
        private string address;

        public Patient(int patientId, string firstName, string lastName, DateTime dateOfBirth, string gender, string contactNumber, string address)
        {
            this.patientId = patientId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.contactNumber = contactNumber;
            this.address = address;
        }

        public int GetPatientId()
        {
            return patientId;
        }

        public void SetPatientId(int value)
        {
            patientId = value;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public void SetFirstName(string value)
        {
            firstName = value;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public void SetLastName(string value)
        {
            lastName = value;
        }

        public DateTime GetDateOfBirth()
        {
            return dateOfBirth;
        }

        public void SetDateOfBirth(DateTime value)
        {
            dateOfBirth = value;
        }

        public string GetGender()
        {
            return gender;
        }

        public void SetGender(string value)
        {
            gender = value;
        }

        public string GetContactNumber()
        {
            return contactNumber;
        }

        public void SetContactNumber(string value)
        {
            contactNumber = value;
        }

        public string GetAddress()
        {
            return address;
        }

        public void SetAddress(string value)
        {
            address = value;
        }
    }
}
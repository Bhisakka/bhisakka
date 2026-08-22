using Bhisakka.Models;
using Npgsql;
using System.Data;

namespace Bhisakka.DataAccess
{
    internal class PatientRepository
    {
        public void InsertPatient(Patient patient)
        {
            string query = @"
                INSERT INTO patients (first_name, last_name, date_of_birth, gender, contact_number, address)
                VALUES (@firstName, @lastName, @dateOfBirth, @gender, @contactNumber, @address);";

            using (var conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@firstName", patient.GetFirstName());
                    cmd.Parameters.AddWithValue("@lastName", patient.GetLastName());
                    cmd.Parameters.AddWithValue("@dateOfBirth", patient.GetDateOfBirth());
                    cmd.Parameters.AddWithValue("@gender", patient.GetGender());
                    cmd.Parameters.AddWithValue("@contactNumber", patient.GetContactNumber());
                    cmd.Parameters.AddWithValue("@address", patient.GetAddress());

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

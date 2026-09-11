using Bhisakka.Models;
using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace Bhisakka.DataAccess
{
    internal class AppointmentRepository
    {
        public List<PatientOption> GetAllPatients()
        {
            List<PatientOption> patients = new List<PatientOption>();

            string query = @"
                SELECT patient_id, first_name || ' ' || last_name AS full_name
                FROM patients
                ORDER BY last_name;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int patientId = reader.GetInt32(reader.GetOrdinal("patient_id"));
                            string fullName = reader.GetString(reader.GetOrdinal("full_name"));
                            patients.Add(new PatientOption(patientId, fullName));
                        }
                    }
                }
            }

            return patients;
        }

        public int InsertAppointment(Appointment appointment)
        {
            string query = @"
                INSERT INTO appointments (patient_id, appointment_date, start_time, end_time, booked_by)
                VALUES (@patientId, @date, @startTime, @endTime, @userId)
                RETURNING appointment_id;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@patientId", appointment.GetPatientId());
                    cmd.Parameters.AddWithValue("@date", appointment.GetAppointmentDate().Date);
                    cmd.Parameters.AddWithValue("@startTime", appointment.GetStartTime());
                    cmd.Parameters.AddWithValue("@endTime", appointment.GetEndTime());
                    cmd.Parameters.AddWithValue("@userId", appointment.GetBookedBy());

                    object result = cmd.ExecuteScalar();
                    return System.Convert.ToInt32(result);
                }
            }
        }
    }
}

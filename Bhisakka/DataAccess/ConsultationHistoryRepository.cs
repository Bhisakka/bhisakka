using Bhisakka.Models;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Bhisakka.DataAccess
{
    internal class ConsultationHistoryRepository
    {
        public List<PatientSearchResult> SearchPatients(string namePrefix)
        {
            List<PatientSearchResult> list = new List<PatientSearchResult>();

            string query = @"
                SELECT patient_id, first_name || ' ' || last_name AS full_name, date_of_birth
                FROM patients
                WHERE first_name ILIKE @search || '%' OR last_name ILIKE @search || '%'
                ORDER BY last_name;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@search", namePrefix);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int dobOrdinal = reader.GetOrdinal("date_of_birth");
                        DateTime dateOfBirth = reader.IsDBNull(dobOrdinal)
                            ? DateTime.MinValue
                            : reader.GetDateTime(dobOrdinal);

                        list.Add(new PatientSearchResult(
                            reader.GetInt32(reader.GetOrdinal("patient_id")),
                            reader.GetString(reader.GetOrdinal("full_name")),
                            dateOfBirth));
                    }
                }
            }

            return list;
        }

        public List<MedicalRecord> GetHistory(int patientId)
        {
            List<MedicalRecord> list = new List<MedicalRecord>();

            string query = @"
                SELECT appointment_date, started_at, diagnosis, notes, consultation_fee, medicines_prescribed
                FROM v_consultation_history
                WHERE patient_id = @patientId
                ORDER BY started_at DESC;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@patientId", patientId);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int diagnosisOrdinal = reader.GetOrdinal("diagnosis");
                        int notesOrdinal = reader.GetOrdinal("notes");
                        string diagnosis = reader.IsDBNull(diagnosisOrdinal) ? "" : reader.GetString(diagnosisOrdinal);
                        string notes = reader.IsDBNull(notesOrdinal) ? "" : reader.GetString(notesOrdinal);

                        ConsultationNote note = new ConsultationNote(diagnosis, notes);

                        MedicalRecord record = new MedicalRecord(
                            reader.GetDateTime(reader.GetOrdinal("appointment_date")),
                            reader.GetDateTime(reader.GetOrdinal("started_at")),
                            reader.GetDecimal(reader.GetOrdinal("consultation_fee")),
                            reader.GetString(reader.GetOrdinal("medicines_prescribed")),
                            note);

                        list.Add(record);
                    }
                }
            }

            return list;
        }
    }
}

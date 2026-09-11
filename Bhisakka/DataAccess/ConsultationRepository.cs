using Bhisakka.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace Bhisakka.DataAccess
{
    internal class ConsultationRepository
    {
        public List<CheckInEntry> GetScheduledForToday()
        {
            List<CheckInEntry> list = new List<CheckInEntry>();

            string query = @"
                SELECT a.appointment_id, p.first_name || ' ' || p.last_name AS patient_name, a.start_time
                FROM appointments a
                JOIN patients p ON p.patient_id = a.patient_id
                WHERE a.appointment_date = CURRENT_DATE AND a.status = 'Scheduled'
                ORDER BY a.start_time;";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new NpgsqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new CheckInEntry(
                        reader.GetInt32(reader.GetOrdinal("appointment_id")),
                        reader.GetString(reader.GetOrdinal("patient_name")),
                        reader.GetTimeSpan(reader.GetOrdinal("start_time"))));
                }
            }

            return list;
        }

        public List<QueueEntry> GetLiveQueue()
        {
            List<QueueEntry> list = new List<QueueEntry>();

            string query = @"
                SELECT a.queue_number, a.appointment_id, a.patient_id, p.first_name || ' ' || p.last_name AS patient_name,
                       a.start_time, a.status
                FROM appointments a
                JOIN patients p ON p.patient_id = a.patient_id
                WHERE a.appointment_date = CURRENT_DATE AND a.status IN ('Waiting', 'InProgress')
                ORDER BY a.queue_number;";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new NpgsqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new QueueEntry(
                        reader.GetInt32(reader.GetOrdinal("appointment_id")),
                        reader.GetInt32(reader.GetOrdinal("patient_id")),
                        reader.GetInt32(reader.GetOrdinal("queue_number")),
                        reader.GetString(reader.GetOrdinal("patient_name")),
                        reader.GetTimeSpan(reader.GetOrdinal("start_time")),
                        reader.GetString(reader.GetOrdinal("status"))));
                }
            }

            return list;
        }

        public void CheckIn(int appointmentId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new NpgsqlCommand(@"
                UPDATE appointments
                SET status = 'Waiting',
                    queue_number = COALESCE((SELECT MAX(queue_number) FROM appointments WHERE appointment_date = CURRENT_DATE), 0) + 1
                WHERE appointment_id = @appointmentId;", conn))
            {
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                cmd.ExecuteNonQuery();
            }
        }

        public int CallNext(int appointmentId, int patientId, int doctorId, decimal defaultFee)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                NpgsqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    using (var cmd = new NpgsqlCommand(
                        "UPDATE appointments SET status = 'InProgress' WHERE appointment_id = @appointmentId AND status <> 'Completed';", conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                        cmd.ExecuteNonQuery();
                    }

                    int consultationId = -1;

                    using (var cmd = new NpgsqlCommand(@"
                        INSERT INTO consultations (appointment_id, patient_id, doctor_id, diagnosis, notes, consultation_fee)
                        VALUES (@appointmentId, @patientId, @doctorId, '', '', @fee)
                        ON CONFLICT (appointment_id) DO NOTHING
                        RETURNING consultation_id;", conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                        cmd.Parameters.AddWithValue("@patientId", patientId);
                        cmd.Parameters.AddWithValue("@doctorId", doctorId);
                        cmd.Parameters.AddWithValue("@fee", defaultFee);

                        object inserted = cmd.ExecuteScalar();
                        if (inserted != null && inserted != DBNull.Value)
                        {
                            consultationId = (int)inserted;
                        }
                    }

                    if (consultationId == -1)
                    {
                        // A consultation already existed for this appointment: resume it.
                        using (var cmd = new NpgsqlCommand(
                            "SELECT consultation_id FROM consultations WHERE appointment_id = @appointmentId;", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                            consultationId = (int)cmd.ExecuteScalar();
                        }
                    }

                    transaction.Commit();
                    return consultationId;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void SaveNotes(int consultationId, string diagnosis, string notes, decimal fee)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new NpgsqlCommand(@"
                UPDATE consultations
                SET diagnosis = @diagnosis, notes = @notes, consultation_fee = @fee, ended_at = now()
                WHERE consultation_id = @consultationId;", conn))
            {
                cmd.Parameters.AddWithValue("@diagnosis", diagnosis);
                cmd.Parameters.AddWithValue("@notes", notes);
                cmd.Parameters.AddWithValue("@fee", fee);
                cmd.Parameters.AddWithValue("@consultationId", consultationId);
                cmd.ExecuteNonQuery();
            }
        }

        public void CompleteAppointment(int appointmentId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new NpgsqlCommand(
                "UPDATE appointments SET status = 'Completed' WHERE appointment_id = @appointmentId;", conn))
            {
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                cmd.ExecuteNonQuery();
            }
        }

        public void CompleteConsultation(int consultationId, int appointmentId, string diagnosis, string notes, decimal fee)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                NpgsqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    using (var cmd = new NpgsqlCommand(@"
                        UPDATE consultations
                        SET diagnosis = @diagnosis, notes = @notes, consultation_fee = @fee, ended_at = now()
                        WHERE consultation_id = @consultationId;", conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@diagnosis", diagnosis);
                        cmd.Parameters.AddWithValue("@notes", notes);
                        cmd.Parameters.AddWithValue("@fee", fee);
                        cmd.Parameters.AddWithValue("@consultationId", consultationId);
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = new NpgsqlCommand(
                        "UPDATE appointments SET status = 'Completed' WHERE appointment_id = @appointmentId;", conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public int CreatePrescription(int consultationId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new NpgsqlCommand(@"
                INSERT INTO prescriptions (consultation_id)
                VALUES (@consultationId)
                RETURNING prescription_id;", conn))
            {
                cmd.Parameters.AddWithValue("@consultationId", consultationId);
                return (int)cmd.ExecuteScalar();
            }
        }

        public void AddPrescriptionItem(int prescriptionId, int medicineId, int quantity, string dosageInstructions)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new NpgsqlCommand(@"
                INSERT INTO prescription_items (prescription_id, medicine_id, quantity, dosage_instructions)
                VALUES (@prescriptionId, @medicineId, @quantity, @dosage);", conn))
            {
                cmd.Parameters.AddWithValue("@prescriptionId", prescriptionId);
                cmd.Parameters.AddWithValue("@medicineId", medicineId);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@dosage", (object)dosageInstructions ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public List<MedicineOption> GetActiveMedicines()
        {
            List<MedicineOption> list = new List<MedicineOption>();

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new NpgsqlCommand(
                "SELECT medicine_id, name, unit_price FROM medicines WHERE is_active ORDER BY name;", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new MedicineOption(
                        reader.GetInt32(reader.GetOrdinal("medicine_id")),
                        reader.GetString(reader.GetOrdinal("name")),
                        reader.GetDecimal(reader.GetOrdinal("unit_price"))));
                }
            }

            return list;
        }
    }
}

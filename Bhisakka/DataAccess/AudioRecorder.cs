using Bhisakka.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhisakka.DataAccess
{
    internal class AudioRecorder        
    {
        public AudioRecorder() { }
        /// <summary>
        /// INSERT a new audio log record into the audio_logs table in the database.
        /// CONSULTATION_ID is a foreign key that references the consultation table.
        /// </summary>
        /// <param name="audioLogs"></param>
        public void InsertConsultation(AudioLogs audioLogs)
        {
            string query = @"INSERT INTO audio_logs (consultation_id, file_path, started_at, duration_seconds, audio_data)
                            VALUES (@consultationId, @filePath, @startedAt, @durationSeconds, @audioData);";
            using (var conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();
                using (var cmd = new Npgsql.NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@consultationId", NpgsqlTypes.NpgsqlDbType.Integer).Value = audioLogs.consultationId;
                    cmd.Parameters.Add("@filePath", NpgsqlTypes.NpgsqlDbType.Varchar, 512).Value = (object)audioLogs.filePath ?? DBNull.Value;
                    cmd.Parameters.Add("@startedAt", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = audioLogs.startedAt;
                    cmd.Parameters.Add("@durationSeconds", NpgsqlTypes.NpgsqlDbType.Double).Value = audioLogs.durationSeconds;                   
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

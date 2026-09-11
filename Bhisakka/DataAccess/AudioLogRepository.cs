using Bhisakka.Models;
using Npgsql;
using System.Data;

namespace Bhisakka.DataAccess
{
    internal class AudioLogRepository
    {
        public void InsertAudioLog(AudioLogs audioLog)
        {
            string query = @"
                INSERT INTO audio_logs (consultation_id, file_path, started_at, duration_seconds)
                VALUES (@consultationId, @filePath, @startedAt, @durationSeconds);";

            using (var conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@consultationId", audioLog.GetConsultationId());
                    cmd.Parameters.AddWithValue("@filePath", audioLog.GetFilePath());
                    cmd.Parameters.AddWithValue("@startedAt", audioLog.GetStartedAt());
                    cmd.Parameters.AddWithValue("@durationSeconds", audioLog.GetDurationSeconds());

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

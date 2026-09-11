using Bhisakka.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace Bhisakka.DataAccess
{
    internal class AudioScheduleRepository
    {
        public List<AudioSchedule> GetDailyPlaylist()
        {
            string query = @"
                SELECT audio_schedule_id, track_name, file_path, track_type, trigger_time
                FROM audio_schedules
                WHERE is_enabled AND trigger_time IS NOT NULL
                ORDER BY trigger_time;";

            return RunQuery(query);
        }

        public List<AudioSchedule> GetManualAnnouncements()
        {
            string query = @"
                SELECT audio_schedule_id, track_name, file_path, track_type, trigger_time
                FROM audio_schedules
                WHERE is_enabled AND trigger_time IS NULL
                ORDER BY track_name;";

            return RunQuery(query);
        }

        private List<AudioSchedule> RunQuery(string query)
        {
            List<AudioSchedule> results = new List<AudioSchedule>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int audioScheduleId = reader.GetInt32(0);
                            string trackName = reader.GetString(1);
                            string filePath = reader.GetString(2);
                            string trackType = reader.GetString(3);

                            TimeSpan? triggerTime = null;
                            if (!reader.IsDBNull(4))
                            {
                                triggerTime = reader.GetTimeSpan(4);
                            }

                            AudioSchedule schedule = new AudioSchedule(audioScheduleId, trackName, filePath, trackType, triggerTime, true);
                            results.Add(schedule);
                        }
                    }
                }
            }

            return results;
        }
    }
}

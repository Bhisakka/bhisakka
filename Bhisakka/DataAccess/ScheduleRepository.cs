using Bhisakka.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Bhisakka.DataAccess
{
    internal class ScheduleRepository
    {
        public List<ScheduleTemplate> GetTemplatesForDay(int dayOfWeek)
        {
            List<ScheduleTemplate> templates = new List<ScheduleTemplate>();

            string query =
                "SELECT template_id, day_of_week, block_type, label, start_time, end_time, slot_duration_minutes, is_active " +
                "FROM schedule_templates WHERE day_of_week = @dayOfWeek AND is_active ORDER BY start_time;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dayOfWeek", dayOfWeek);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            templates.Add(ReadTemplate(reader));
                        }
                    }
                }
            }

            return templates;
        }

        public List<ScheduleTemplate> GetAllTemplates()
        {
            List<ScheduleTemplate> templates = new List<ScheduleTemplate>();

            string query =
                "SELECT template_id, day_of_week, block_type, label, start_time, end_time, slot_duration_minutes, is_active " +
                "FROM schedule_templates ORDER BY day_of_week, start_time;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        templates.Add(ReadTemplate(reader));
                    }
                }
            }

            return templates;
        }

        public void InsertTemplate(ScheduleTemplate template)
        {
            string query =
                "INSERT INTO schedule_templates (day_of_week, block_type, label, start_time, end_time, slot_duration_minutes, is_active) " +
                "VALUES (@dayOfWeek, @blockType, @label, @startTime, @endTime, @slotDurationMinutes, @isActive);";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    AddTemplateParameters(cmd, template);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTemplate(ScheduleTemplate template)
        {
            string query =
                "UPDATE schedule_templates SET day_of_week = @dayOfWeek, block_type = @blockType, label = @label, " +
                "start_time = @startTime, end_time = @endTime, slot_duration_minutes = @slotDurationMinutes, is_active = @isActive " +
                "WHERE template_id = @templateId;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    AddTemplateParameters(cmd, template);
                    cmd.Parameters.AddWithValue("@templateId", template.GetTemplateId());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTemplate(int templateId)
        {
            string query = "DELETE FROM schedule_templates WHERE template_id = @templateId;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@templateId", templateId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Tuple<TimeSpan, TimeSpan>> GetBlockedSlotsForDate(DateTime date)
        {
            List<Tuple<TimeSpan, TimeSpan>> ranges = new List<Tuple<TimeSpan, TimeSpan>>();

            string query = "SELECT start_time, end_time FROM blocked_slots WHERE block_date = @date;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", date.Date);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TimeSpan start = reader.GetFieldValue<TimeSpan>(0);
                            TimeSpan end = reader.GetFieldValue<TimeSpan>(1);
                            ranges.Add(new Tuple<TimeSpan, TimeSpan>(start, end));
                        }
                    }
                }
            }

            return ranges;
        }

        public void InsertBlockedSlot(BlockedSlot blockedSlot)
        {
            string query =
                "INSERT INTO blocked_slots (block_date, start_time, end_time, reason, created_by) " +
                "VALUES (@blockDate, @startTime, @endTime, @reason, @createdBy);";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@blockDate", blockedSlot.GetBlockDate().Date);
                    cmd.Parameters.AddWithValue("@startTime", blockedSlot.GetStartTime());
                    cmd.Parameters.AddWithValue("@endTime", blockedSlot.GetEndTime());

                    if (string.IsNullOrEmpty(blockedSlot.GetReason()))
                    {
                        cmd.Parameters.AddWithValue("@reason", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@reason", blockedSlot.GetReason());
                    }

                    cmd.Parameters.AddWithValue("@createdBy", blockedSlot.GetCreatedBy());

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Tuple<TimeSpan, TimeSpan>> GetBookedSlotsForDate(DateTime date)
        {
            List<Tuple<TimeSpan, TimeSpan>> ranges = new List<Tuple<TimeSpan, TimeSpan>>();

            string query =
                "SELECT start_time, end_time FROM appointments WHERE appointment_date = @date AND status <> 'Cancelled';";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", date.Date);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TimeSpan start = reader.GetFieldValue<TimeSpan>(0);
                            TimeSpan end = reader.GetFieldValue<TimeSpan>(1);
                            ranges.Add(new Tuple<TimeSpan, TimeSpan>(start, end));
                        }
                    }
                }
            }

            return ranges;
        }

        public int GetBookingWindowDays()
        {
            int windowDays = 3;

            string query = "SELECT setting_value FROM app_settings WHERE setting_key = 'booking_window_days';";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        int parsed;
                        if (int.TryParse(Convert.ToString(result, CultureInfo.InvariantCulture), out parsed))
                        {
                            windowDays = parsed;
                        }
                    }
                }
            }

            return windowDays;
        }

        private void AddTemplateParameters(NpgsqlCommand cmd, ScheduleTemplate template)
        {
            cmd.Parameters.AddWithValue("@dayOfWeek", template.GetDayOfWeek());
            cmd.Parameters.AddWithValue("@blockType", template.GetBlockType());
            cmd.Parameters.AddWithValue("@label", template.GetLabel());
            cmd.Parameters.AddWithValue("@startTime", template.GetStartTime());
            cmd.Parameters.AddWithValue("@endTime", template.GetEndTime());

            if (template.GetSlotDurationMinutes().HasValue)
            {
                cmd.Parameters.AddWithValue("@slotDurationMinutes", template.GetSlotDurationMinutes().Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@slotDurationMinutes", DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@isActive", template.GetIsActive());
        }

        private ScheduleTemplate ReadTemplate(NpgsqlDataReader reader)
        {
            int templateId = reader.GetInt32(0);
            int dayOfWeek = Convert.ToInt32(reader.GetValue(1));
            string blockType = reader.GetString(2);
            string label = reader.GetString(3);
            TimeSpan startTime = reader.GetFieldValue<TimeSpan>(4);
            TimeSpan endTime = reader.GetFieldValue<TimeSpan>(5);
            int? slotDurationMinutes = null;

            if (!reader.IsDBNull(6))
            {
                slotDurationMinutes = Convert.ToInt32(reader.GetValue(6));
            }

            bool isActive = reader.GetBoolean(7);

            return new ScheduleTemplate(templateId, dayOfWeek, blockType, label, startTime, endTime, slotDurationMinutes, isActive);
        }
    }
}

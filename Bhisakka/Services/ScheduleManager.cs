using Bhisakka.DataAccess;
using Bhisakka.Models;
using System;
using System.Collections.Generic;

namespace Bhisakka.Services
{
    internal class ScheduleManager
    {
        private ScheduleRepository scheduleRepository;

        public ScheduleManager()
        {
            scheduleRepository = new ScheduleRepository();
        }

        public List<TimeSlot> GetAvailableSlots(DateTime date)
        {
            List<TimeSlot> availableSlots = new List<TimeSlot>();

            int dayOfWeek = (int)date.DayOfWeek;
            List<ScheduleTemplate> templates = scheduleRepository.GetTemplatesForDay(dayOfWeek);
            List<Tuple<TimeSpan, TimeSpan>> blockedRanges = scheduleRepository.GetBlockedSlotsForDate(date);
            List<Tuple<TimeSpan, TimeSpan>> bookedRanges = scheduleRepository.GetBookedSlotsForDate(date);

            bool isToday = date.Date == DateTime.Today;
            TimeSpan timeNow = DateTime.Now.TimeOfDay;

            for (int i = 0; i < templates.Count; i++)
            {
                ScheduleTemplate template = templates[i];

                if (!string.Equals(template.GetBlockType(), "Consultation", StringComparison.Ordinal))
                {
                    continue;
                }

                if (!template.GetSlotDurationMinutes().HasValue)
                {
                    continue;
                }

                TimeSpan duration = TimeSpan.FromMinutes(template.GetSlotDurationMinutes().Value);
                TimeSpan blockStart = template.GetStartTime();
                TimeSpan blockEnd = template.GetEndTime();
                TimeSpan cursor = blockStart;

                while (cursor + duration <= blockEnd)
                {
                    TimeSpan pieceStart = cursor;
                    TimeSpan pieceEnd = cursor + duration;

                    bool alreadyPassed = isToday && pieceStart <= timeNow;

                    if (!alreadyPassed
                        && !OverlapsAny(pieceStart, pieceEnd, blockedRanges)
                        && !OverlapsAny(pieceStart, pieceEnd, bookedRanges))
                    {
                        availableSlots.Add(new TimeSlot(pieceStart, pieceEnd));
                    }

                    cursor = cursor + duration;
                }
            }

            return availableSlots;
        }

        public int GetBookingWindowDays()
        {
            return scheduleRepository.GetBookingWindowDays();
        }

        private static bool OverlapsAny(TimeSpan pieceStart, TimeSpan pieceEnd, List<Tuple<TimeSpan, TimeSpan>> ranges)
        {
            for (int i = 0; i < ranges.Count; i++)
            {
                TimeSpan otherStart = ranges[i].Item1;
                TimeSpan otherEnd = ranges[i].Item2;

                if (pieceStart < otherEnd && otherStart < pieceEnd)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

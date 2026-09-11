using Bhisakka.DataAccess;
using Bhisakka.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bhisakka.Audio
{
    internal class AudioScheduler
    {
        private const int PollIntervalMs = 30000;

        private readonly AudioScheduleRepository repository;
        private readonly IAudioPlayer player;
        private readonly Timer timer;
        private readonly Dictionary<int, DateTime> lastPlayedDates;

        private List<AudioSchedule> dailyPlaylist;
        private AudioSchedule currentTrack;

        public event EventHandler<AudioSchedule> TrackStarted;
        public event EventHandler PlaybackStopped;

        public AudioScheduler()
        {
            repository = new AudioScheduleRepository();
            player = new NAudioPlayer();
            player.PlaybackFinished += OnPlaybackFinished;

            lastPlayedDates = new Dictionary<int, DateTime>();
            dailyPlaylist = new List<AudioSchedule>();

            timer = new Timer();
            timer.Interval = PollIntervalMs;
            timer.Tick += OnTimerTick;
        }

        public void Start()
        {
            dailyPlaylist = repository.GetDailyPlaylist();
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            EvaluateSchedule();
        }

        private void EvaluateSchedule()
        {
            if (player.IsPlaying())
            {
                return;
            }

            DateTime now = DateTime.Now;
            TimeSpan currentTime = now.TimeOfDay;

            for (int i = 0; i < dailyPlaylist.Count; i++)
            {
                AudioSchedule schedule = dailyPlaylist[i];

                if (!schedule.GetIsEnabled() || !schedule.GetTriggerTime().HasValue)
                {
                    continue;
                }

                if (currentTime < schedule.GetTriggerTime().Value)
                {
                    continue;
                }

                bool alreadyPlayedToday = false;
                DateTime lastPlayed;
                if (lastPlayedDates.TryGetValue(schedule.GetAudioScheduleId(), out lastPlayed))
                {
                    if (lastPlayed.Date == now.Date)
                    {
                        alreadyPlayedToday = true;
                    }
                }

                if (!alreadyPlayedToday)
                {
                    lastPlayedDates[schedule.GetAudioScheduleId()] = now;
                    PlayTrack(schedule);
                    break;
                }
            }
        }

        private void PlayTrack(AudioSchedule schedule)
        {
            currentTrack = schedule;
            player.Play(schedule.GetFilePath());

            EventHandler<AudioSchedule> handler = TrackStarted;
            if (handler != null)
            {
                handler(this, schedule);
            }
        }

        public void PlayAnnouncement(AudioSchedule announcement)
        {
            if (announcement == null)
            {
                return;
            }

            PlayTrack(announcement);
        }

        public void PausePlayback()
        {
            player.Pause();
        }

        public void ResumePlayback()
        {
            player.Resume();
        }

        public void StopPlayback()
        {
            player.Stop();
        }

        public bool IsPlaying()
        {
            return player.IsPlaying();
        }

        public AudioSchedule GetCurrentTrack()
        {
            return currentTrack;
        }

        private void OnPlaybackFinished(object sender, EventArgs e)
        {
            currentTrack = null;

            EventHandler handler = PlaybackStopped;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}

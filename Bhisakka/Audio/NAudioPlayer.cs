using System;
using System.IO;
using NAudio.Wave;

namespace Bhisakka.Audio
{
    internal class NAudioPlayer : IAudioPlayer
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private bool isPlaying;

        public event EventHandler PlaybackFinished;

        public void Play(string filePath)
        {
            Stop();

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return;
            }

            try
            {
                audioFile = new AudioFileReader(filePath);
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                outputDevice.Play();
                isPlaying = true;
            }
            catch (Exception)
            {
                CleanUp();
                isPlaying = false;
            }
        }

        public void Pause()
        {
            if (outputDevice != null && outputDevice.PlaybackState == PlaybackState.Playing)
            {
                outputDevice.Pause();
                isPlaying = false;
            }
        }

        public void Resume()
        {
            if (outputDevice != null && outputDevice.PlaybackState == PlaybackState.Paused)
            {
                outputDevice.Play();
                isPlaying = true;
            }
        }

        public void Stop()
        {
            if (outputDevice != null)
            {
                outputDevice.PlaybackStopped -= OnPlaybackStopped;
                outputDevice.Stop();
            }
            CleanUp();
            isPlaying = false;
        }

        public bool IsPlaying()
        {
            return isPlaying && outputDevice != null && outputDevice.PlaybackState == PlaybackState.Playing;
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            CleanUp();
            isPlaying = false;

            EventHandler handler = PlaybackFinished;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void CleanUp()
        {
            if (outputDevice != null)
            {
                outputDevice.Dispose();
                outputDevice = null;
            }

            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }
        }
    }
}

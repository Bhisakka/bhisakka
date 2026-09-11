using System;

namespace Bhisakka.Audio
{
    internal interface IAudioPlayer
    {
        void Play(string filePath);
        void Pause();
        void Resume();
        void Stop();
        bool IsPlaying();
        event EventHandler PlaybackFinished;
    }
}

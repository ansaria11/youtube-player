using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using NAudio.Wave;

namespace youtube_player
{
    public class Song
    {
        private string location;
        public string name;
        private double currentPos;
        private AudioFileReader audioFile;
        private WaveOutEvent outputDevice;
        private bool initialised = false;

        public Song(string path, string name)
        {
            this.name = name;
            location = path;
            audioFile = new AudioFileReader(path);
        }

        public void ChangeVolume(float volume)
        {
            if (initialised)
            {
                outputDevice.Volume = volume;
            }
        }

        public void InitialiseSong()
        {
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.PlaybackStopped += (object? sender, StoppedEventArgs e) => Terminate(); ;
            initialised = true;
            
        }

        public void Terminate()
        {
            if (initialised)
            {
                outputDevice.Dispose();
                initialised = false;
            }
        }

        public void Play()
        {
            if (initialised)
            {
                if (outputDevice.PlaybackState == PlaybackState.Stopped)
                {
                    outputDevice.Play();
                }
            }
        }

        public void Pause()
        {
            if (initialised)
            {
                if (outputDevice.PlaybackState != PlaybackState.Playing)
                {
                    outputDevice.Pause();
                }
            }
        }
    }
}
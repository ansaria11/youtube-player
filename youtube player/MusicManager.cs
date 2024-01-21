using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace youtube_player
{
    public class MusicManager
    {
        public List<Playlist> Playlists = new List<Playlist>();
        private const string projectDirectory = "C:\\Users\\adama\\Documents\\Coding\\AudioProject\\";

        public MusicManager() { }

        public Song CreateSong(string url, Playlist playlist, string name)
        {
            //-p C:/Users/adama/Documents/Coding/AudioProject -o %(uploader)s/%(title)s.%(wav)s
            string ytdl = projectDirectory + "yt-dlp.exe";
            string songDirectory = projectDirectory + "\\Playlists\\" + playlist.name + "\\" + name;
            //.\yt-dlp.exe -x --audio-format wav -o C:\Users\adama\Documents\Coding\AudioProject\favs\sweaterweather https://www.youtube.com/watch?v=dzs9dgKfU4Q
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = ytdl;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "-x --audio-format wav -o " + songDirectory + " " + url;
            process.StartInfo = startInfo;
            process.Start(); process.WaitForExit(); process.Kill();
            Song result = new Song(songDirectory + ".wav", name);
            playlist.Add(result);
            return result;
        }

        public void LoadPlaylists()
        {
            foreach (var playlistFolder in Directory.CreateDirectory(projectDirectory + "\\Playlists\\").EnumerateDirectories()) 
            {
                Playlist playlist = new Playlist(playlistFolder.Name);
                foreach(var songFile in playlistFolder.EnumerateFiles())
                {
                    playlist.Songs.Add(new Song(songFile.DirectoryName + "\\" + songFile.Name, songFile.Name.Substring(0, songFile.Name.Length - 4)));
                }
                Playlists.Add(playlist);
            }
        }

        public void CreatePlaylist(string name)
        {
            Playlists.Add(new Playlist(name));
        }
    }
}

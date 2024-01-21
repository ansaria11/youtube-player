using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace youtube_player
{
    public class Playlist
    {
        public List<Song> Songs;
        public string name;
        private string directory;
        private const string projectFolder = "C:\\Users\\adama\\Documents\\Coding\\AudioProject\\";

        public Playlist(string name) 
        {
            Songs = new List<Song>();
            this.name = name;
            directory = projectFolder + name;
        }

        public void Shuffle()
        {
            List<Song> list = new List<Song>();
            Random random = new Random();
            for (int i = 0; i < Songs.Count; i++)
            {
                int n = random.Next(0, Songs.Count);
                list.Add(Songs[n]);
                Songs.RemoveAt(n);
            }
            Songs = list;
        }

        public void Add(Song song)
        {
            Songs.Add(song);
        }

        public void Remove(Song song)
        {
            Songs.Remove(song);
        }

        public void Clear()
        {
            Songs = new List<Song>();
        }
    }
}

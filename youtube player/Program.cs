using Google.Apis.YouTube.v3;
using Google.Apis;
using Google.Apis.Services;
using System.Text.Json;
using Google.Apis.YouTube.v3.Data;
using System.Threading.Tasks;
using System;


namespace youtube_player
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MusicManager mManager = new MusicManager();
            YoutubeInterface yt = new();
            string videoName = Console.ReadLine() ?? "";
            var x = await yt.GetVideoReference(videoName);
            if (yt.ValidateResponse(x)) 
            { 
                string url = yt.ConvertToUrl(x.Items[0]);
                Playlist pL = mManager.CreatePlaylist("favs");
                Song sweaterweather = mManager.CreateSong(url, pL, String.Join("", videoName.ToCharArray().Where(x => !Char.IsWhiteSpace(x))));
            }
        }

        static Playlist GetPlaylistChoice(MusicManager manager)
        {
            Console.Clear();
            Dictionary<int, Playlist> map = new();
            int count = 1;
            foreach (Playlist playlist in manager.Playlists)
            {
                Console.WriteLine(playlist.name + $" [{count}]");
                map.Add(count, playlist);
                count += 1;
            }
            return map[Int32.Parse(Console.ReadLine())];
        }

        static void RunUI(MusicManager manager)
        {
            Playlist choice = GetPlaylistChoice(manager);
            Console.WriteLine("Choose Song [1]");
            Console.WriteLine("Add Song [2]");
            Console.WriteLine("\nPlaylist Selection[0]");
        }
    }
}

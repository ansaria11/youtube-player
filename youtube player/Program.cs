using Google.Apis.YouTube.v3;
using Google.Apis;
using Google.Apis.Services;
using System.Text.Json;
using Google.Apis.YouTube.v3.Data;
namespace youtube_player
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MusicManager mManager = new MusicManager();
            mManager.LoadPlaylists();
            
            switch (Console.ReadLine())
            {
                case "1":

                    break;
                case "2":

                    break;
                case "0":

                    break;

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

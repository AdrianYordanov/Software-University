using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var songs = new List<Song>();

        for (int i = 0; i < n; i++)
        {
            try
            {
                var tokens = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var artistName = tokens[0];
                var songName = tokens[1];
                var timeTokens = new List<long>();

                try
                {
                    timeTokens = tokens[2].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                }
                catch (Exception)
                {
                    throw new ArgumentException("Invalid song length.");
                }

                var minutes = timeTokens[0];
                var seconds = timeTokens[1];

                var song = new Song(artistName, songName, minutes, seconds);
                songs.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        var totalTime = TimeSpan.FromSeconds(songs.Sum(s => s.SongLength.TotalSeconds));
        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine($"Playlist length: {totalTime.Hours}h {totalTime.Minutes}m {totalTime.Seconds}s");
    }
}
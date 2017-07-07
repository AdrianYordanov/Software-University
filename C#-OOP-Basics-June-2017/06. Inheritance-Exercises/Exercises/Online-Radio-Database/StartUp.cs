using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var songs = new List<Song>();
        var attempts = int.Parse(Console.ReadLine());

        for (int i = 0; i < attempts; i++)
        {
            try
            {
                var input = Console.ReadLine()
                   .ToLower()
                   .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var timeTokens = new List<int>();

                try
                {
                    timeTokens = input[2].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
                }
                catch (Exception)
                {
                    throw new InvalidSongLengthException();
                }

                songs.Add(new Song(input[0], input[1], timeTokens[0], timeTokens[1]));
                Console.WriteLine("Song added.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        TimeSpan totalTime = TimeSpan.FromSeconds(songs.Sum(s => s.SongLength.TotalSeconds));
        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine($"Playlist length: {totalTime.Hours}h {totalTime.Minutes}m {totalTime.Seconds}s");
    }
}
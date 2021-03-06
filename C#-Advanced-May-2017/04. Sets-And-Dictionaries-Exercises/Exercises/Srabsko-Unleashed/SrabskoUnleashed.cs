﻿using System;
using System.Collections.Generic;
using System.Linq;

public class SrabskoUnleashed
{
    private static void Main()
    {
        var venues = new Dictionary<string, Dictionary<string, long>>();
        string line;
        while ((line = Console.ReadLine()) != "End")
        {
            try
            {
                var tokens = line.Split(new[] { " @" }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length != 2)
                {
                    continue;
                }

                var firstTokens = tokens[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var secondTokens = tokens[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var singer = string.Join(" ", firstTokens);
                var venue = string.Join(" ", secondTokens.Take(secondTokens.Length - 2));
                var ticketPrice = long.Parse(secondTokens[secondTokens.Length - 1]);
                var ticketsCount = long.Parse(secondTokens[secondTokens.Length - 2]);
                if (venues.ContainsKey(venue))
                {
                    if (venues[venue].ContainsKey(singer))
                    {
                        venues[venue][singer] += ticketPrice * ticketsCount;
                    }
                    else
                    {
                        venues[venue].Add(singer, ticketPrice * ticketsCount);
                    }
                }
                else
                {
                    var singers = new Dictionary<string, long> { { singer, ticketPrice * ticketsCount } };
                    venues.Add(venue, singers);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        foreach (var pair in venues)
        {
            var venue = pair.Key;
            var singers = pair.Value;
            var sortedSingers = singers.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine(venue);
            foreach (var nestedPair in sortedSingers)
            {
                Console.WriteLine($"#  {nestedPair.Key} -> {nestedPair.Value}");
            }
        }
    }
}
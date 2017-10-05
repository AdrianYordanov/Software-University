using System;
using System.Collections.Generic;

public class HandsOfCards
{
    private static string[] cards;
    private static string[] multiplier;

    public static void Main()
    {
        var input = string.Empty;
        var people = new Dictionary<string, HashSet<string>>();
        cards = new[]
        {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "J",
            "Q",
            "K",
            "A"
        };
        multiplier = new[]
        {
            "C",
            "D",
            "H",
            "S"
        };
        while ((input = Console.ReadLine()) != "JOKER")
        {
            var tokens = input.Split(':');
            var player = tokens[0];
            var playerCards = tokens[1]
                .Split(
                    new[]
                    {
                        ' ',
                        ','
                    },
                    StringSplitOptions.RemoveEmptyEntries);
            if (people.ContainsKey(player))
            {
                people[player]
                    .UnionWith(playerCards);
            }
            else
            {
                people.Add(player, new HashSet<string>(playerCards));
            }
        }

        foreach (var player in people.Keys)
        {
            var playerScore = CalculateScore(people[player]);
            Console.WriteLine($"{player}: {playerScore}");
        }
    }

    private static int CalculateScore(IEnumerable<string> playerCards)
    {
        var cardsScore = 0;
        foreach (var card in playerCards)
        {
            var tempScore = (Array.IndexOf(cards, card.Remove(card.Length - 1)) + 2) *
                            (Array.IndexOf(
                                 multiplier,
                                 card[card.Length - 1].ToString()) +
                             1);
            cardsScore += tempScore;
        }

        return cardsScore;
    }
}
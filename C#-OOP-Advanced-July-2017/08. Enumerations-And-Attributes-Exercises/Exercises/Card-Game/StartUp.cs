using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static string playerOneName;
    private static string playerTwoName;
    private static IList<Card> playerOneCards;
    private static IList<Card> playerTwoCards;
    private static IList<string> cardRankNames;
    private static IList<string> cardSuitNames;

    public static void Main()
    {
        playerOneCards = new List<Card>();
        playerTwoCards = new List<Card>();
        cardRankNames = new List<string>(Enum.GetNames(typeof(Rank)));
        cardSuitNames = new List<string>(Enum.GetNames(typeof(Suit)));
        playerOneName = Console.ReadLine();
        playerTwoName = Console.ReadLine();
        while (playerOneCards.Count < 5 ||
               playerTwoCards.Count < 5)
        {
            ProcessCard(
                Console.ReadLine()
                    .Split(
                        new[]
                        {
                            " of "
                        },
                        StringSplitOptions.RemoveEmptyEntries)
                    .ToList());
        }

        var winnerInfo = GetWinner();
        Console.WriteLine(winnerInfo);
    }

    private static void ProcessCard(IReadOnlyList<string> cardInfo)
    {
        var cardRank = cardInfo[0];
        var cardSuit = cardInfo[1];
        if (CardIsValid(cardRank, cardSuit))
        {
            if (CardIsAvailable(cardRank, cardSuit))
            {
                if (playerOneCards.Count < 5)
                {
                    playerOneCards.Add(new Card(cardRank, cardSuit));
                }
                else
                {
                    playerTwoCards.Add(new Card(cardRank, cardSuit));
                }
            }
            else
            {
                Console.WriteLine("Card is not in the deck.");
            }
        }
        else
        {
            Console.WriteLine("No such card exists.");
        }
    }

    private static bool CardIsAvailable(string cardRank, string cardSuit)
    {
        var playerOneCardsInHand = new List<string>();
        var playerTwoCardsInHand = new List<string>();
        foreach (var card in playerOneCards)
        {
            playerOneCardsInHand.Add($"{card.Rank} of {card.Suit}");
        }

        foreach (var card in playerTwoCards)
        {
            playerTwoCardsInHand.Add($"{card.Rank} of {card.Suit}");
        }

        var cardToCheck = $"{cardRank} of {cardSuit}";
        return playerOneCardsInHand.All(c => c != cardToCheck) && playerTwoCardsInHand.All(c => c != cardToCheck);
    }

    private static bool CardIsValid(string cardRank, string cardSuit)
    {
        return cardRankNames.Contains(cardRank) && cardSuitNames.Contains(cardSuit);
    }

    private static string GetWinner()
    {
        var bestCardPlayerOne = playerOneCards.OrderByDescending(c => c.CardPower).First();
        var bestCardPlayerTwo = playerTwoCards.OrderByDescending(c => c.CardPower).First();
        return bestCardPlayerOne.CardPower >= bestCardPlayerTwo.CardPower ?
            $"{playerOneName} wins with {bestCardPlayerOne.Rank} of {bestCardPlayerOne.Suit}." :
            $"{playerTwoName} wins with {bestCardPlayerTwo.Rank} of {bestCardPlayerTwo.Suit}.";
    }
}
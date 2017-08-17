using System;

public class StartUp
{
    public static void Main()
    {
        var rank = Console.ReadLine();
        var suit = Console.ReadLine();
        var firstCard = new Card(rank, suit);
        rank = Console.ReadLine();
        suit = Console.ReadLine();
        var secondCard = new Card(rank, suit);
        Console.WriteLine(firstCard.CompareTo(secondCard) > 0 ? firstCard : secondCard);
    }
}
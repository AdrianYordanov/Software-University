using System;

public class StartUp
{
    public static void Main()
    {
        Console.WriteLine("Card Suits:");
        foreach (var suit in Enum.GetNames(typeof(Suit)))
        {
            Console.WriteLine($"Ordinal value: {(int)Enum.Parse(typeof(Suit), suit)}; Name value: {suit}");
        }
    }
}
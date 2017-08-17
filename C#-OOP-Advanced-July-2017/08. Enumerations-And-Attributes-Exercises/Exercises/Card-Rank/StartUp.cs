using System;

public class StartUp
{
    public static void Main()
    {
        Console.WriteLine("Card Ranks:");
        foreach (var rank in Enum.GetNames(typeof(Rank)))
        {
            Console.WriteLine($"Ordinal value: {(int)Enum.Parse(typeof(Rank), rank)}; Name value: {rank}");
        }
    }
}
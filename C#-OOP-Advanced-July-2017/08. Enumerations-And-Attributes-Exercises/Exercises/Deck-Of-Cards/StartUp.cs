using System;

public class StartUp
{
    public static void Main()
    {
        foreach (var suit in Enum.GetNames(typeof(Suit)))
        {
            foreach (var rank in Enum.GetNames(typeof(Rank)))
            {
                Console.WriteLine($"{rank} of {suit}");
            }
        }
    }
}
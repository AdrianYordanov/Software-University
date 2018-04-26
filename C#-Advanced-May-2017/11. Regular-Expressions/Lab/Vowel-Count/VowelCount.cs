using System;
using System.Text.RegularExpressions;

public class VowelCount
{
    private static void Main()
    {
        var text = Console.ReadLine();
        var regex = new Regex("[AEIOUYaeiouy]");
        var count = regex.Matches(text).Count;
        Console.WriteLine($"Vowels: {count}");
    }
}
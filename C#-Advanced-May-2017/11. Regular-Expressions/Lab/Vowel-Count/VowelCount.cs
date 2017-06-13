using System;
using System.Text.RegularExpressions;

class VowelCount
{
    static void Main()
    {
        var text = Console.ReadLine();
        var regex = new Regex("[aeiouy]", RegexOptions.IgnoreCase);
        var count = regex.Matches(text).Count;
        Console.WriteLine($"Vowels: {count}");
    }
}
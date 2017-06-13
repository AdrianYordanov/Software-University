using System;
using System.Text.RegularExpressions;


class MatchCount
{
    static void Main()
    {
        var pattern = Console.ReadLine();
        var text = Console.ReadLine();
        var regex = new Regex(pattern);
        var match = regex.Match(text);
        var counter = 0;

        while (match.Success)
        {
            ++counter;
            match = match.NextMatch();
        }

        Console.WriteLine(counter);
    }
}
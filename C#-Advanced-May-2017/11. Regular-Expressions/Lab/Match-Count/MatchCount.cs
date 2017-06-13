using System;
using System.Text.RegularExpressions;


class MatchCount
{
    static void Main()
    {
        var pattern = Console.ReadLine();
        var text = Console.ReadLine();
        var regex = new Regex(pattern);
        var count = regex.Matches(text).Count;
        Console.WriteLine(count);
    }
}
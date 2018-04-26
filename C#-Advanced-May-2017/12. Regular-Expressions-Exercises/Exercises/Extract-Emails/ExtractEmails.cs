using System;
using System.Text.RegularExpressions;

public class ExtractEmails
{
    private static void Main()
    {
        var text = Console.ReadLine();
        var pattern =
            @"(?<=[\s])([a-zA-Z0-9]+([\.\-_]?[a-zA-Z0-9]+)*)@([a-zA-Z]+(\-?[a-zA-Z]+)*)(\.([a-zA-Z]+(\-?[a-zA-Z]+)*))+";
        var regex = new Regex(pattern);
        var matches = regex.Matches(text);
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
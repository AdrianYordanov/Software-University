using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        var text = Console.ReadLine();
        string pattern = @"(?<=[\s])([a-zA-Z0-9]+([\.\-_]?[a-zA-Z0-9]+)*)@([a-zA-Z]+(\-?[a-zA-Z]+)*)(\.([a-zA-Z]+(\-?[a-zA-Z]+)*))+";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
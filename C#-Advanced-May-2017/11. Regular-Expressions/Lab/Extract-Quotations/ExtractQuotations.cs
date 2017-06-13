using System;
using System.Text.RegularExpressions;

class ExtractQuotations
{
    static void Main()
    {
        var text = Console.ReadLine();
        var regex = new Regex("('|\")(.*?)\\1");
        var matches = regex.Matches(text);

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Groups[2]);
        }
    }
}
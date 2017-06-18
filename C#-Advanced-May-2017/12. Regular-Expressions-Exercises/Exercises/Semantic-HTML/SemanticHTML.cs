using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class SemanticHTML
{
    static void Main()
    {
        List<string> result = new List<string>();
        Regex openTagRegex = new Regex(@"<div\s+.*((id|class)\s*=\s*""(main|header|nav|article|section|aside|footer)"").*>");
        Regex closeTagRegex = new Regex(@"<\/div>(\s*<!--\s*(main|header|nav|article|section|aside|footer)\s*-->)");
        string line;

        while ((line = Console.ReadLine()) != "END")
        {
            bool tagOpen = openTagRegex.IsMatch(line);
            bool tagClose = closeTagRegex.IsMatch(line);

            if (!(tagOpen || tagClose))
            {
                result.Add(line);
                continue;
            }
            if (tagOpen)
            {
                Match match = openTagRegex.Match(line);
                line = Regex.Replace(line, "div", match.Groups[3].Value);
                line = Regex.Replace(line, match.Groups[1].Value, string.Empty);
            }
            else
            {
                Match match = closeTagRegex.Match(line);
                line = Regex.Replace(line, "div", match.Groups[2].Value);
                line = Regex.Replace(line, match.Groups[1].Value, string.Empty);
            }
            line = Regex.Replace(line, @"<\s+", "<");
            line = Regex.Replace(line, @"\s+>", ">");
            line = Regex.Replace(line, @"([^\s]+)\s+", "$1 ");
            result.Add(line);
        }

        foreach (var inputLine in result)
        {
            Console.WriteLine(inputLine);
        }
    }
}
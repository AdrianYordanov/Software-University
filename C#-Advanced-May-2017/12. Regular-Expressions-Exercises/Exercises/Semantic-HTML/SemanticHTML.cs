using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class SemanticHTML
{
    private static void Main()
    {
        var result = new List<string>();
        var openTagRegex = new Regex(
            @"<div\s+.*((id|class)\s*=\s*""(main|header|nav|article|section|aside|footer)"").*>");
        var closeTagRegex = new Regex(@"<\/div>(\s*<!--\s*(main|header|nav|article|section|aside|footer)\s*-->)");
        string line;
        while ((line = Console.ReadLine()) != "END")
        {
            var tagOpen = openTagRegex.IsMatch(line);
            var tagClose = closeTagRegex.IsMatch(line);
            if (!(tagOpen || tagClose))
            {
                result.Add(line);
                continue;
            }

            if (tagOpen)
            {
                var match = openTagRegex.Match(line);
                line = Regex.Replace(line, "div", match.Groups[3].Value);
                line = Regex.Replace(line, match.Groups[1].Value, string.Empty);
            }
            else
            {
                var match = closeTagRegex.Match(line);
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
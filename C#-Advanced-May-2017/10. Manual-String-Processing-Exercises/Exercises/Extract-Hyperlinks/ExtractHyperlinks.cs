using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractHyperlinks
{
    static void Main()
    {
        string line = string.Empty;
        StringBuilder html = new StringBuilder();

        while ((line = Console.ReadLine()) != "END")
        {
            html.Append(line);
        }

        Regex aPattern = new Regex(@"<a.+?>");
        Regex hrefPattern = new Regex(@"href\s*=\s*((?<quotes>\""|')(?<res1>.+?)\k<quotes>|(?<res2>[^\""'][^\s>]+))");
        var matchedTags = aPattern.Matches(html.ToString());

        foreach (Match tag in matchedTags)
        {
            if (!hrefPattern.IsMatch(tag.Value))
            {
                continue;
            }

            var href = hrefPattern.Match(tag.Value);
            var firstResult = href.Groups["res1"];
            var secondResult = href.Groups["res2"];
            Console.WriteLine(firstResult.Length == 0 ? secondResult : firstResult);
        }
    }
}
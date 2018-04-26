using System;
using System.Text;
using System.Text.RegularExpressions;

public class ExtractHyperlinks
{
    private static void Main()
    {
        string line;
        var html = new StringBuilder();
        while ((line = Console.ReadLine()) != "END")
        {
            html.Append(line);
        }

        var tagPattern = new Regex(@"<a.+?>");
        var hrefPattern = new Regex(@"href\s*=\s*((?<quotes>\""|')(?<res1>.+?)\k<quotes>|(?<res2>[^\""'][^\s>]+))");
        var matchedTags = tagPattern.Matches(html.ToString());
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
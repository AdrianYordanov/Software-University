using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractHyperlinks
{
    static void Main()
    {
        var input = string.Empty;
        var html = new StringBuilder();
        var regex = new Regex(@"<a\s+[^>]*href\s*=\s*((?<quotes>\""|')(?<res1>.+?)\k<quotes>|(?<res2>[^\""'][^\s>]+)).*?>");

        while ((input = Console.ReadLine()) != "END")
        {
            html.Append(input);
        }

        var tags = regex.Matches(html.ToString());

        foreach (Match matchedTag in tags)
        {
            var firstResult = matchedTag.Groups["res1"];
            var secondResult = matchedTag.Groups["res2"];
            Console.WriteLine(firstResult.Length == 0 ? secondResult : firstResult);
        }
    }
}
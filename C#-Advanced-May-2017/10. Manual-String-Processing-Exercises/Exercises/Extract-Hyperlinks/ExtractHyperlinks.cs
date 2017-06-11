using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractHyperlinks
{
    static void Main()
    {
        string line;
        StringBuilder html = new StringBuilder();
        while ((line = Console.ReadLine()) != "END")
            html.Append(line);
        string htmlStr = html.ToString();

        Regex aPattern = new Regex(@"<\s*a\s+[^>]+?>", RegexOptions.IgnoreCase);

        Regex hrefVal = new Regex(@"href\s*=\s*([\u0022'])(.+?)\1");
        foreach (Match anchor in aPattern.Matches(htmlStr))
        {
            string anchorStr = anchor.Value;
            Match m = hrefVal.Match(anchor.Value);
            if (m.Success)
                Console.WriteLine(m.Groups[2].Value);
        }
    }
}
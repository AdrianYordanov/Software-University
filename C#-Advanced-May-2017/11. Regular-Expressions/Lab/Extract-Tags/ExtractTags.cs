using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ExtractTags
{
    private static void Main()
    {
        var tags = new List<string>();
        string input;
        var regex = new Regex("<.+?>");
        while ((input = Console.ReadLine()) != "END")
        {
            var matches = regex.Matches(input);
            foreach (Match matchedTag in matches)
            {
                tags.Add(matchedTag.Value);
            }
        }

        foreach (var tag in tags)
        {
            Console.WriteLine(tag);
        }
    }
}
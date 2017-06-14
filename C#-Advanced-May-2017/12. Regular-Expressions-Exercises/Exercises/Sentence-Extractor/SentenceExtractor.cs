using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class SentenceExtractor
{
    static void Main()
    {
        var word = Console.ReadLine();
        var text = Console.ReadLine();
        var result = new List<string>();
        var sentenceRegex = new Regex($@"[^.?!]*(?<=[.?\s!]){word}(?=[\s.?!])[^.?!]*[.?!]");
        var sentences = sentenceRegex.Matches(text);

        foreach (Match sentence in sentences)
        {
            result.Add(sentence.Value);
        }

        foreach (var sentence in result)
        {
            Console.WriteLine(sentence);
        }
    }
}
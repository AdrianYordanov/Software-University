using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class QueryMess
{
    private static void Main()
    {
        string line;
        var result = new StringBuilder();
        var regex = new Regex(@"(?<=&|^)(.*?)=(.*?)(?=&|$)");
        while ((line = Console.ReadLine()) != "END")
        {
            var linkTokens = line.Split('?');
            if (linkTokens.Length > 1)
            {
                line = linkTokens[1];
            }

            var pairs = new Dictionary<string, List<string>>();
            var matchedPairs = regex.Matches(line);
            foreach (Match currentPair in matchedPairs)
            {
                var key = currentPair.Groups[1].ToString();
                var value = currentPair.Groups[2].ToString();
                key = Regex.Replace(key, @"(%20|\+)", " ");
                key = Regex.Replace(key, @"[ \s]+", " ").Trim();
                value = Regex.Replace(value, @"(%20|\+)", " ");
                value = Regex.Replace(value, @"[ \s]+", " ").Trim();
                if (!pairs.ContainsKey(key))
                {
                    pairs.Add(key, new List<string>());
                }

                pairs[key].Add(value);
            }

            foreach (var pair in pairs)
            {
                result.Append($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
            }

            result.AppendLine();
        }

        Console.Write(result);
    }
}
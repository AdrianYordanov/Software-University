using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class MatchFullName
{
    static void Main()
    {
        var regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");
        var names = new List<string>();
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "end")
        {
            var matches = regex.Matches(input);

            foreach (Match matchedName in matches)
            {
                names.Add(matchedName.Value);
            }
        }

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class MatchPhoneNumber
{
    static void Main()
    {
        var regex = new Regex(@"(?<=^| )\+359( |\-)2\1\d{3}\1\d{4}\b");
        var numbers = new List<string>();
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "end")
        {
            var matches = regex.Matches(input);

            foreach (Match matchedName in matches)
            {
                numbers.Add(matchedName.Value);
            }
        }

        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
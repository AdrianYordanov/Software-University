using System;
using System.Text;
using System.Text.RegularExpressions;

class UseYourChainsBuddy
{
    static void Main()
    {
        var input = Console.ReadLine();
        var result = new StringBuilder();
        var pRegex = new Regex(@"<p>(.*?)<\/p>");
        var matches = pRegex.Matches(input);

        foreach (Match tagContent in matches)
        {
            var inside = tagContent.Groups[1].Value;
            inside = Regex.Replace(inside, "[^a-z0-9]+", " ");
            inside = Regex.Replace(inside, @"[ \s]+", " ");
            var temp = new StringBuilder(inside);

            for (int i = 0; i < temp.Length; i++)
            {
                var letter = inside[i];

                if (Regex.IsMatch(letter.ToString(), "[a-m]"))
                {
                    letter = (char)(letter + 13);
                }
                else if (Regex.IsMatch(letter.ToString(), "[n-z]"))
                {
                    letter = (char)(letter - 13);
                }

                temp[i] = letter;
            }

            result.Append(temp);
        }

        Console.WriteLine(result);
    }
}
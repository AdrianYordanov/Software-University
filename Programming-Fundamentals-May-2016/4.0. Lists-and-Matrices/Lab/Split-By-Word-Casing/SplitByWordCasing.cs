using System;
using System.Collections.Generic;
using System.Linq;

class SplitByWordCasing
{
    enum WordType { LowerCase, UpperCase, MixedCase };

    static void Main()
    {
        var separators = new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' };
        var words = Console.ReadLine()
            .Split(separators, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var lowerCaseList = new List<string>();
        var upperCaseList = new List<string>();
        var mixedCaseList = new List<string>();

        foreach (var word in words)
        {
            WordType result = GetWordType(word);

            switch (result)
            {
                case WordType.LowerCase: lowerCaseList.Add(word); break;
                case WordType.UpperCase: upperCaseList.Add(word); break;
                case WordType.MixedCase: mixedCaseList.Add(word); break;
            }
        }

        Console.WriteLine("Lower-case: {0}", string.Join(", ", lowerCaseList));
        Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCaseList));
        Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCaseList));
    }

    private static WordType GetWordType(string word)
    {
        int lowerCaseCount = 0,
            upperCaseCount = 0;

        foreach (var letter in word)
        {
            if (char.IsLower(letter))
            {
                ++lowerCaseCount;
            }
            else if (char.IsUpper(letter))
            {
                ++upperCaseCount;
            }
        }

        if (lowerCaseCount == word.Length)
        {
            return WordType.LowerCase;
        }

        if (upperCaseCount == word.Length)
        {
            return WordType.UpperCase;
        }

        return WordType.MixedCase;
    }
}
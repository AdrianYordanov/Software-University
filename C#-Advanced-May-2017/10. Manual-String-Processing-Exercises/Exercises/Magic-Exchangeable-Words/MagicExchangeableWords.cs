using System;
using System.Collections.Generic;

class MagicExchangeableWords
{
    static void Main()
    {
        var input = Console.ReadLine().Split(' ');
        var firstString = input[0];
        var secondString = input[1];
        var areExchangeable = true;
        var shorter = string.Empty;
        var longer = string.Empty;
        var dictionary = new Dictionary<char, char>();

        if (firstString.Length <= secondString.Length)
        {
            shorter = firstString;
            longer = secondString;
        }
        else
        {
            shorter = secondString;
            longer = firstString;
        }

        var remainingString = longer.Substring(shorter.Length);

        for (int i = 0; i < shorter.Length; i++)
        {
            if (dictionary.ContainsKey(firstString[i]))
            {
                var value = dictionary[firstString[i]];

                if (value != secondString[i])
                {
                    areExchangeable = false;
                    break;
                }
            }
            else
            {
                if (dictionary.ContainsValue(secondString[i]))
                {
                    areExchangeable = false;
                    break;
                }
                else
                {
                    dictionary.Add(firstString[i], secondString[i]);
                }
            }
        }

        foreach (var letter in remainingString)
        {
            if (!dictionary.ContainsKey(letter) && !dictionary.ContainsValue(letter))
            {
                areExchangeable = false;
                break;
            }
        }

        Console.WriteLine(areExchangeable ? "true" : "false");
    }
}
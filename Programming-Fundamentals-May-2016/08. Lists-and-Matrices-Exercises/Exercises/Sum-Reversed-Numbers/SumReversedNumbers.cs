using System;
using System.Collections.Generic;
using System.Linq;

class SumReversedNumbers
{
    static void Main()
    {
        var sum = Console
            .ReadLine()
            .Split(' ')
            .ToList()
            .Select(text => int.Parse(ReverseString(text)))
            .Sum();

        Console.WriteLine(sum);

    }

    static string ReverseString(string numberAsString)
    {
        char[] charArray = numberAsString.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
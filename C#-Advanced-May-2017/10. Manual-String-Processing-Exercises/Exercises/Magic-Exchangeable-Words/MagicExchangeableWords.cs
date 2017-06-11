using System;
using System.Collections.Generic;

class MagicExchangeableWords
{
    static void Main()
    {
        var input = Console.ReadLine().Split(' ');
        var firstUnique = new HashSet<char>();
        var secondUnique = new HashSet<char>();

        foreach (char character in input[0])
        {
            firstUnique.Add(character);
        }

        foreach (char character in input[1])
        {
            secondUnique.Add(character);
        }

        if (firstUnique.Count == secondUnique.Count)
        {

            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}
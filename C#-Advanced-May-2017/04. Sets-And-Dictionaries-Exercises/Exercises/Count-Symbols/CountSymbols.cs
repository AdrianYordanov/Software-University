using System;
using System.Collections.Generic;

public class CountSymbols
{
    private static void Main()
    {
        var input = Console.ReadLine();
        var container = new SortedDictionary<char, int>();
        foreach (var character in input)
        {
            if (!container.ContainsKey(character))
            {
                container.Add(character, 1);
            }
            else
            {
                container[character]++;
            }
        }

        foreach (var character in container.Keys)
        {
            Console.WriteLine($"{character}: {container[character]} time/s");
        }
    }
}
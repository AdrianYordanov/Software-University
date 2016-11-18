using System;
using System.Collections.Generic;
using System.Linq;

class BombNumbers
{
    static void Main()
    {
        var list = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();
        var secondLineTokens = Console.ReadLine()
            .Split(' ');
        var bomb = int.Parse(secondLineTokens[0]);
        var power = int.Parse(secondLineTokens[1]);


        for (int i = 0; i < list.Count; i++)
        {
            if (list.ElementAt(i) == bomb)
            {
                for (int powerIterator = 0; powerIterator < power && i > 0; powerIterator++, --i)
                {
                    list.RemoveAt(i - 1);
                }

                for (int powerIterator = 0; powerIterator < power && i < list.Count - 1; powerIterator++)
                {
                    list.RemoveAt(i + 1);
                }

                list.RemoveAt(i);
                --i;
            }
        }

        Console.WriteLine(list.Sum());
    }
}
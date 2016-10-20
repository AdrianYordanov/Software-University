using System;
using System.Collections.Generic;
using System.Linq;

class SumAdjacentEqualNumbers
{
    static void Main()
    {
        var list = Console.ReadLine()
            .Split(' ')
            .Select(decimal.Parse)
            .ToList();

        int index = 1;
        while (index < list.Count)
        {
            if (list[index] == list[index - 1])
            {
                list.RemoveAt(index);
                list[index - 1] *= 2;
                index = index - 2;

                if (index < 0)
                {
                    index = 0;
                }
            }

            ++index;
        }

        Console.WriteLine(string.Join(" ", list));
    }
}
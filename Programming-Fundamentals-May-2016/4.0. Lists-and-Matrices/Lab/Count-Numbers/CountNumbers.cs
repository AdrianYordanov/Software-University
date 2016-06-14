using System;
using System.Collections.Generic;
using System.Linq;

class CountNumbers
{
    static void Main()
    {
        var list = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();
        var array = new int[1001];

        foreach (var num in list)
        {
            array[num]++;
        }

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > 0)
            {
                Console.WriteLine("{0} -> {1}", i, array[i]);
            }
        }
    }
}
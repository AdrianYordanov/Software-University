using System;
using System.Collections.Generic;
using System.Linq;

class SortNumbers
{
    static void Main()
    {
        var nums = Console.ReadLine()
            .Split(' ')
            .Select(decimal.Parse)
            .ToList();

        nums.Sort();

        Console.WriteLine(string.Join(" <= ", nums));
    }
}
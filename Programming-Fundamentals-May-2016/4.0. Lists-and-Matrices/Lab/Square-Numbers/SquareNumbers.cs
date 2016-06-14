using System;
using System.Collections.Generic;
using System.Linq;

class SquareNumbers
{
    static void Main()
    {
        var nums = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();
        var result = new List<int>();

        foreach (var num in nums)
        {
            double sqrt = Math.Sqrt(num);

            if (sqrt == (int)sqrt)
            {
                result.Add(num);
            }
        }

        result.Sort((a, b) => b.CompareTo(a));
        Console.WriteLine(string.Join(" ", result));
    }
}
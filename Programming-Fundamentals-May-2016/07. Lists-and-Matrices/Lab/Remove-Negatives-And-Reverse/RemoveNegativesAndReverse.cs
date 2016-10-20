using System;
using System.Collections.Generic;
using System.Linq;

class RemoveNegativesAndReverse
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
            if (num > 0)
            {
                result.Add(num);
            }
        }

        if (result.Count > 0)
        {
            result.Reverse();
            Console.WriteLine(string.Join(" ", result));
        }
        else
        {
            Console.WriteLine("empty");
        }
    }
}
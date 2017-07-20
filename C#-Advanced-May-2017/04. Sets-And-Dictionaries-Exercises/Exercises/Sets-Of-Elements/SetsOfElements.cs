using System;
using System.Collections.Generic;
using System.Linq;

public class SetsOfElements
{
    public static void Main()
    {
        var tokens = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        var firstSet = new HashSet<int>();
        var secondSet = new HashSet<int>();
        for (var i = 0; i < tokens[0]; i++)
        {
            var number = int.Parse(Console.ReadLine());
            firstSet.Add(number);
        }

        for (var i = 0; i < tokens[1]; i++)
        {
            var number = int.Parse(Console.ReadLine());
            secondSet.Add(number);
        }

        foreach (var item in firstSet)
        {
            if (secondSet.Contains(item))
            {
                Console.Write(item + " ");
            }
        }
    }
}
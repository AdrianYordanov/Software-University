using System;
using System.Collections.Generic;

public class PeriodicTable
{
    private static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var sortedSet = new SortedSet<string>();
        for (var i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(' ');
            foreach (var token in tokens)
            {
                sortedSet.Add(token);
            }
        }

        foreach (var str in sortedSet)
        {
            Console.Write(str + " ");
        }
    }
}
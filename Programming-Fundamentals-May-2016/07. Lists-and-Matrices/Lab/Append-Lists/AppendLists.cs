using System;
using System.Collections.Generic;
using System.Linq;

class AppendLists
{
    static void Main()
    {
        var strings = Console.ReadLine()
            .Split('|')
            .ToList();
        var result = new List<int>();

        strings.Reverse();
        foreach (var str in strings)
        {
            var tempList = str
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            result.AddRange(tempList);
        }

        Console.WriteLine(string.Join(" ", result));
    }
}
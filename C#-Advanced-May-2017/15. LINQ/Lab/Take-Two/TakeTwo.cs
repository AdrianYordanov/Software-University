using System;
using System.Linq;

public class TakeTwo
{
    private static void Main()
    {
        var result = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .Where(number => number >= 10 && number <= 20)
            .Take(2)
            .ToList();
        Console.WriteLine(string.Join(" ", result));
    }
}
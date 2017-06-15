using System;
using System.Linq;

class FindAndSumIntegers
{
    static void Main()
    {
        long temp = 0;
        var numbers = Console.ReadLine()
            .Split(' ')
            .Where(x => long.TryParse(x, out temp))
            .Select(long.Parse)
            .ToList();
        Console.WriteLine(numbers.Count == 0 ? "No match" : numbers.Sum().ToString());
    }
}
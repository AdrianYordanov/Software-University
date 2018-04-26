using System;
using System.Linq;

public class FindAndSumIntegers
{
    private static void Main()
    {
        var numbers = Console.ReadLine().Split(' ').Where(x => long.TryParse(x, out _)).Select(long.Parse).ToList();
        Console.WriteLine(numbers.Count == 0 ? "No match" : numbers.Sum().ToString());
    }
}
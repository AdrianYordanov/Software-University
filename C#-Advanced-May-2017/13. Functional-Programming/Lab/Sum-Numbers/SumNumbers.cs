using System;
using System.Linq;

internal class SumNumbers
{
    private static void Main()
    {
        var input = Console.ReadLine();
        Func<string, int> count = x =>
            x.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().Count;
        Func<string, int> sum = x =>
            x.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Sum();
        Console.WriteLine(count(input));
        Console.WriteLine(sum(input));
    }
}
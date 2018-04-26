using System;
using System.Linq;

public class SortEvenNumbers
{
    private static void Main()
    {
        var sorted = Console.ReadLine()
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(number => number % 2 == 0)
            .OrderBy(x => x);
        Console.WriteLine(string.Join(", ", sorted));
    }
}
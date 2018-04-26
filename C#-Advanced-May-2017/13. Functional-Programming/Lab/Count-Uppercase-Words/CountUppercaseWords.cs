using System;
using System.Linq;

public class CountUppercaseWords
{
    private static void Main()
    {
        Func<string, bool> isUpperCase = x => char.IsUpper(x[0]);
        Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(isUpperCase)
            .ToList()
            .ForEach(Console.WriteLine);
    }
}
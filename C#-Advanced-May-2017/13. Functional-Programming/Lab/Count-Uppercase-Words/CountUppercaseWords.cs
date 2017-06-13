using System;
using System.Linq;

class CountUppercaseWords
{
    static void Main()
    {
        Func<string, bool> isUpperCase = x => char.IsUpper(x[0]);
        Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(isUpperCase)
            .ToList()
            .ForEach(x => Console.WriteLine(x));
    }
}
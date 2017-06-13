using System;
using System.Linq;

class SortEvenNumbers
{
    static void Main()
    {
        var sorted = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .Where(number => number % 2 == 0)
           .OrderBy(x => x);
        Console.WriteLine(string.Join(", ", sorted));
    }
}
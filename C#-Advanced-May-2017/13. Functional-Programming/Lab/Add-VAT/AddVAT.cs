using System;
using System.Linq;

class AddVAT
{
    static void Main()
    {
        Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => double.Parse(x) * 1.2)
            .ToList()
            .ForEach(x => Console.WriteLine($"{x:F2}"));
    }
}
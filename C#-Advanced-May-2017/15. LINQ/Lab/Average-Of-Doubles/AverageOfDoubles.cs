using System;
using System.Linq;

class AverageOfDoubles
{
    static void Main()
    {
        var result = Console.ReadLine()
            .Split(' ')
            .Select(double.Parse)
            .Average();
        Console.WriteLine($"{result:F2}");
    }
}
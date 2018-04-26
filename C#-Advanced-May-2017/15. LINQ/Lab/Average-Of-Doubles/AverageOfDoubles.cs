using System;
using System.Linq;

public class AverageOfDoubles
{
    private static void Main()
    {
        var result = Console.ReadLine().Split(' ').Select(double.Parse).Average();
        Console.WriteLine($"{result:F2}");
    }
}
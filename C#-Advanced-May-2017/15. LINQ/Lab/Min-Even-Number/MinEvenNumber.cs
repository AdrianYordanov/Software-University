using System;
using System.Linq;

public class MinEvenNumber
{
    private static void Main()
    {
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        var evenNumbers = Console.ReadLine().Split(' ').Select(double.Parse).Where(number => number % 2 == 0).ToList();
        Console.WriteLine(evenNumbers.Count == 0 ? "No match" : $"{evenNumbers.Min():F2}");
    }
}
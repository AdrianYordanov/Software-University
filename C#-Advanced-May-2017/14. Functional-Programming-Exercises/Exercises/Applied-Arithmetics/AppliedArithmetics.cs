using System;
using System.Collections.Generic;
using System.Linq;

class AppliedArithmetics
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split(' ')
            .Select(int.Parse)
            .ToList();
        var line = string.Empty;

        while ((line = Console.ReadLine()) != "end")
        {
            switch (line)
            {
                case "add": Add(numbers); break;
                case "subtract": Subtract(numbers); break;
                case "multiply": Multiply(numbers); break;
                case "print": Print(numbers); break;
            }
        }
    }

    private static void Add(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            numbers[i]++;
        }
    }

    private static void Subtract(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            numbers[i]--;
        }
    }

    private static void Multiply(List<int> numbers)
    {

        for (int i = 0; i < numbers.Count; i++)
        {
            numbers[i] *= 2;
        }
    }

    private static void Print(List<int> numbers)
    {
        Console.WriteLine(string.Join(" ", numbers));
    }
}
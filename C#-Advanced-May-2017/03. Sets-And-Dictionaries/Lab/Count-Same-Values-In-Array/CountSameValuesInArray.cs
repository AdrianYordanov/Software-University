using System;
using System.Collections.Generic;
using System.Linq;

public class CountSameValuesInArray
{
    public static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();
        var dictionary = new SortedDictionary<double, int>();
        foreach (var currentNumber in numbers)
        {
            if (!dictionary.ContainsKey(currentNumber))
            {
                dictionary.Add(currentNumber, 1);
            }
            else
            {
                dictionary[currentNumber]++;
            }
        }

        foreach (var key in dictionary.Keys)
        {
            Console.WriteLine($"{key} - {dictionary[key]} times");
        }
    }
}
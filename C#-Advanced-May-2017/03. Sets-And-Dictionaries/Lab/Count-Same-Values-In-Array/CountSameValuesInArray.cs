using System;
using System.Collections.Generic;
using System.Linq;

class CountSameValuesInArray
{
    static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();
        var dictionary = new SortedDictionary<double, int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            var currentNumber = numbers[i];

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
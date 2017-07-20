using System;
using System.Collections.Generic;

public class MinersTask
{
    public static void Main()
    {
        var input = string.Empty;
        var dictionary = new Dictionary<string, long>();
        while ((input = Console.ReadLine()) != "stop")
        {
            var quantity = long.Parse(Console.ReadLine());

            if (dictionary.ContainsKey(input))
            {
                dictionary[input] += quantity;
            }
            else
            {
                dictionary.Add(input, quantity);
            }
        }

        foreach (var resource in dictionary.Keys)
        {
            Console.WriteLine($"{resource} -> {dictionary[resource]}");
        }
    }
}
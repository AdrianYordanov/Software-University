﻿using System;
using System.Collections.Generic;

public class SoftUniParty
{
    private static void Main()
    {
        var guestes = new SortedSet<string>();
        string input;
        while ((input = Console.ReadLine()) != "PARTY")
        {
            guestes.Add(input);
        }

        while ((input = Console.ReadLine()) != "END")
        {
            if (guestes.Contains(input))
            {
                // The person is going.
                guestes.Remove(input);
            }
        }

        Console.WriteLine(guestes.Count);
        foreach (var personNumber in guestes)
        {
            Console.WriteLine(personNumber);
        }
    }
}
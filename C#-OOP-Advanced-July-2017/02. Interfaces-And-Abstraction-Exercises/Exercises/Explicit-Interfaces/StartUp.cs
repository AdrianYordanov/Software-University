using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var persons = new List<Citizen>();
        var input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split(' ');
            persons.Add(new Citizen(tokens[0], tokens[1], int.Parse(tokens[2])));
        }

        foreach (var citizen in persons)
        {
            Console.WriteLine(citizen);
        }
    }
}
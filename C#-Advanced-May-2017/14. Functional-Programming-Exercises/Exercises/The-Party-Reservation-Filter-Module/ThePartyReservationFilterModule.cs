using System;
using System.Collections.Generic;
using System.Linq;

public class ThePartyReservationFilterModule
{
    private static void Main()
    {
        var names = Console.ReadLine().Split(' ').ToList();
        var startsWithCollection = new HashSet<string>();
        var endsWithCollection = new HashSet<string>();
        var lengthsCollection = new HashSet<int>();
        var containsCollection = new HashSet<string>();
        string line;
        while ((line = Console.ReadLine()) != "Print")
        {
            var tokens = line.Split(';');
            var command = tokens[0];
            var filter = tokens[1];
            var parameter = tokens[2];
            if (command == "Add filter")
            {
                switch (filter)
                {
                    case "Starts with":
                        startsWithCollection.Add(parameter);
                        break;
                    case "Ends with":
                        endsWithCollection.Add(parameter);
                        break;
                    case "Length":
                        lengthsCollection.Add(int.Parse(parameter));
                        break;
                    case "Contains":
                        containsCollection.Add(parameter);
                        break;
                }
            }
            else if (command == "Remove filter")
            {
                switch (filter)
                {
                    case "Starts with":
                        startsWithCollection.Remove(parameter);
                        break;
                    case "Ends with":
                        endsWithCollection.Remove(parameter);
                        break;
                    case "Length":
                        lengthsCollection.Remove(int.Parse(parameter));
                        break;
                    case "Contains":
                        containsCollection.Remove(parameter);
                        break;
                }
            }
        }

        startsWithCollection.ToList()
            .ForEach(
                x =>
                    {
                        Predicate<string> startsWith = str => str.StartsWith(x);
                        names = names.Where(name => !startsWith(name)).ToList();
                    });
        endsWithCollection.ToList()
            .ForEach(
                x =>
                    {
                        Predicate<string> endsWith = str => str.EndsWith(x);
                        names = names.Where(name => !endsWith(name)).ToList();
                    });
        lengthsCollection.ToList()
            .ForEach(
                x =>
                    {
                        Predicate<string> lengthIs = str => str.Length == x;
                        names = names.Where(name => !lengthIs(name)).ToList();
                    });
        containsCollection.ToList()
            .ForEach(
                x =>
                    {
                        Predicate<string> contains = str => str.Contains(x);
                        names = names.Where(name => !contains(name)).ToList();
                    });
        Console.WriteLine(string.Join(" ", names));
    }
}
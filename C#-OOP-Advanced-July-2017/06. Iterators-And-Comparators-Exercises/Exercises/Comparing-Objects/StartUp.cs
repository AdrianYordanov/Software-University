using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var input = string.Empty;
        var people = new List<Person>();
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(
                    new[]
                    {
                        ' '
                    },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
        }

        var n = int.Parse(Console.ReadLine()) - 1;
        var specialPerson = people[n];
        if (people.Count(x => x.CompareTo(specialPerson) == 0) > 1)
        {
            var equalPeople = people.Count(p => p.CompareTo(specialPerson) == 0);
            var unequalPeople = people.Count(p => p.CompareTo(specialPerson) != 0);
            Console.WriteLine($"{equalPeople} {unequalPeople} {people.Count}");
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(' ');
            people.Add(new Person(tokens[0], int.Parse(tokens[1])));
        }

        var filteredPeople = people
            .Where(person => person.Age > 30)
            .OrderBy(person => person.Name);
        Console.WriteLine(string.Join(Environment.NewLine, filteredPeople));
    }
}
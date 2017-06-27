using System;
using System.Collections.Generic;
using System.Linq;

class GroupByGroup
{
    static void Main()
    {
        var input = string.Empty;
        var students = new List<Person>();

        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var current = new Person()
            {
                Name = $"{tokens[0]} {tokens[1]}",
                Group = int.Parse(tokens[2])
            };

            students.Add(current);
        }

        var groups = students
            .GroupBy(s => s.Group, s => s.Name)
            .OrderBy(x => x.Key);

        foreach (var group in groups)
        {
            Console.WriteLine(group.Key + " - " + string.Join(", ", group));
        }
    }
}

public class Person
{
    public string Name { get; set; }
    public int Group { get; set; }
}
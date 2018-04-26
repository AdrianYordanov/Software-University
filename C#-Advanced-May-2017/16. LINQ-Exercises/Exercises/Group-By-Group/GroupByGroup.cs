using System;
using System.Collections.Generic;
using System.Linq;

public class GroupByGroup
{
    private static void Main()
    {
        string input;
        var students = new List<Person>();
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var current = new Person($"{tokens[0]} {tokens[1]}", int.Parse(tokens[2]));
            students.Add(current);
        }

        var groups = students.GroupBy(s => s.Group, s => s.Name).OrderBy(x => x.Key);
        foreach (var group in groups)
        {
            Console.WriteLine(group.Key + " - " + string.Join(", ", group));
        }
    }
}
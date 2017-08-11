using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var setOne = new SortedSet<Person>(new NameComparator());
        var setTwo = new SortedSet<Person>(new AgeComparator());
        var n = int.Parse(Console.ReadLine());
        for (var i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine()
                .Split(
                    new[]
                    {
                        ' '
                    },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var person = new Person(tokens[0], int.Parse(tokens[1]));
            setOne.Add(person);
            setTwo.Add(person);
        }

        if (setOne.Count > 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, setOne));
            Console.WriteLine(string.Join(Environment.NewLine, setTwo));
        }
    }
}
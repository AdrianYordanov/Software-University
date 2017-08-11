using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var sortedSet = new SortedSet<Person>();
        var hashSet = new HashSet<Person>();
        var personCount = int.Parse(Console.ReadLine());
        for (var i = 0; i < personCount; i++)
        {
            var personTokens = Console.ReadLine().Split(' ');
            var person = new Person(personTokens[0], int.Parse(personTokens[1]));
            sortedSet.Add(person);
            hashSet.Add(person);
        }

        Console.WriteLine(sortedSet.Count);
        Console.WriteLine(hashSet.Count);
    }
}
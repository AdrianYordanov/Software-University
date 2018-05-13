using System;
using System.Collections.Generic;
using System.Reflection;

public class StartUp
{
    private static void Main()
    {
        var personType = typeof(Person);
        var fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine(fields.Length);
        var people = new List<Person> { new Person("Pesho", 20), new Person("Gosho", 18), new Person("Stamat", 43) };
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Name} {person.Age}");
        }
    }
}
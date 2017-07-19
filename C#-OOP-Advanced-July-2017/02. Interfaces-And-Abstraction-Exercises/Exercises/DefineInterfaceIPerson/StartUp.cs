using System;

// ReSharper disable once CheckNamespace
public class StartUp
{
    static void Main()
    {
        var personInterface = typeof(Citizen).GetInterface("IPerson");
        var properties = personInterface.GetProperties();
        Console.WriteLine(properties.Length);
        var name = Console.ReadLine();
        // ReSharper disable once AssignNullToNotNullAttribute
        var age = int.Parse(Console.ReadLine());
        var person = new Citizen(name, age);
        Console.WriteLine(person.Name);
        Console.WriteLine(person.Age);
    }
}
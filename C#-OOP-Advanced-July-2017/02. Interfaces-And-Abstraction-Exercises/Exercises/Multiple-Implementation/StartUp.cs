using System;

// ReSharper disable once CheckNamespace
public class StartUp
{
    private static void Main()
    {
        var identifiableInterface = typeof(Citizen).GetInterface("IIdentifiable");
        var birthableInterface = typeof(Citizen).GetInterface("IBirthable");
        var properties = identifiableInterface.GetProperties();
        Console.WriteLine(properties.Length);
        Console.WriteLine(properties[0].PropertyType.Name);
        properties = birthableInterface.GetProperties();
        Console.WriteLine(properties.Length);
        Console.WriteLine(properties[0].PropertyType.Name);
        var name = Console.ReadLine();
        // ReSharper disable once AssignNullToNotNullAttribute
        var age = int.Parse(Console.ReadLine());
        var id = Console.ReadLine();
        var birthdate = Console.ReadLine();
        // ReSharper disable once UnusedVariable
        IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
        // ReSharper disable once UnusedVariable
        IBirthable birthable = new Citizen(name, age, id, birthdate);
    }
}
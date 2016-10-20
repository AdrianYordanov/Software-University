using System;

class AnimalType
{
    static void Main()
    {
        string animal = Console.ReadLine();
        string message = string.Empty;

        switch (animal)
        {
            case "dog": message = "mammal"; break;
            case "crocodile":
            case "tortoise":
            case "snake": message = "reptile"; break;
            default: message = "unknown"; break;
        }

        Console.WriteLine(message);
    }
}
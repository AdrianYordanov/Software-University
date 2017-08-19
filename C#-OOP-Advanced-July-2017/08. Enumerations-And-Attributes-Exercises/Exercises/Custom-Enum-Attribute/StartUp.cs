using System;

public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine();
        var enumType = Type.GetType(input);
        var attributes = enumType.GetCustomAttributes(false);
        var firstAttribute = (TypeAttribute)attributes[0];
        Console.WriteLine($"Type = {firstAttribute.Type}, Description = {firstAttribute.Description}");
    }
}
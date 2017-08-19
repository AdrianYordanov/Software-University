using System;

[Info("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public class StartUp
{
    public static void Main()
    {
        var input = string.Empty;
        var attr = (InfoAttribute)typeof(StartUp).GetCustomAttributes(true)[0];
        while ((input = Console.ReadLine()) != "END")
        {
            attr.PrintInfo(input);
        }
    }
}
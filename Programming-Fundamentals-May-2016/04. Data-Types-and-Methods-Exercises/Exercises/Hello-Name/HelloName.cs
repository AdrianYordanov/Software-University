using System;

class HelloName
{
    static void Main()
    {
        string input = Console.ReadLine();
        PrintName(input);
    }

    private static void PrintName(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }
}
using System;

class Greeting
{
    static void Main()
    {
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        byte age = byte.Parse(Console.ReadLine());

        Console.WriteLine("Hello, {0} {1}. You are {2} years old.", firstName, lastName, age);
        //Interpolated string -> Console.WriteLine($"Hello, {firstName} {lastName}. You are {age} years old.");
    }
}
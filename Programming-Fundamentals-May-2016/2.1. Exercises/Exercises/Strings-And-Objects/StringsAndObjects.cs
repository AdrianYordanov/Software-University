using System;

class StringsAndObjects
{
    static void Main()
    {
        string firstString = "Hello";
        string secondString = "World";
        object concatenated = firstString + " " + secondString;
        string result = (string)concatenated;
        Console.WriteLine(result);
    }
}
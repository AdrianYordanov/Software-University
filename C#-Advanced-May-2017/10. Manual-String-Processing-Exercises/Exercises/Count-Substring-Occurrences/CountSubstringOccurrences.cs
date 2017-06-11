using System;

class CountSubstringOccurrences
{
    static void Main()
    {
        var text = Console.ReadLine().ToLower();
        var searchString = Console.ReadLine().ToLower();

        var foundIndex = -1;
        var stringCounter = 0;

        while ((foundIndex = text.IndexOf(searchString, foundIndex + 1)) != -1)
        {
            ++stringCounter;
        }

        Console.WriteLine(stringCounter);
    }
}

using System;
using System.Linq;

class UpperStrings
{
    static void Main()
    {
        var result = Console.ReadLine()
            .Split(' ')
            .Select(character => character.ToUpper());
        Console.WriteLine(string.Join(" ", result));
    }
}
using System;
using System.Linq;

public class UpperStrings
{
    private static void Main()
    {
        var result = Console.ReadLine().Split(' ').Select(character => character.ToUpper());
        Console.WriteLine(string.Join(" ", result));
    }
}
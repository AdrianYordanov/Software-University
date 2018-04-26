using System;
using System.Linq;

public class UnicodeCharacters
{
    private static void Main()
    {
        var line = Console.ReadLine();
        var uniocdeArray = line.Select(x => $"\\u{(int)x:x4}");
        Console.WriteLine(string.Join(string.Empty, uniocdeArray));
    }
}
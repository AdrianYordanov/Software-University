using System;
using System.Linq;

class UnicodeCharacters
{
    static void Main()
    {
        var line = Console.ReadLine();
        var uniocdeArray = line.Select(x => string.Format("\\u{0:x4}", (int)x));
        Console.WriteLine(string.Join(string.Empty, uniocdeArray));
    }
}
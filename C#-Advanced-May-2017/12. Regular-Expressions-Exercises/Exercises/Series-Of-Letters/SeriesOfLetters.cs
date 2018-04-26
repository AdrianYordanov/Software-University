using System;
using System.Text.RegularExpressions;

public class SeriesOfLetters
{
    private static void Main()
    {
        var text = Console.ReadLine();
        var regex = new Regex(@"(.)\1+");
        var result = regex.Replace(text, "$1");
        Console.WriteLine(result);
    }
}
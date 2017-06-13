using System;
using System.Text.RegularExpressions;

class ExtractIntegerNumbers
{
    static void Main()
    {
        var text = Console.ReadLine();
        var regex = new Regex(@"\d+");
        var numbers = regex.Matches(text);

        foreach (Match matchedNumber in numbers)
        {
            Console.WriteLine(matchedNumber.Value);
        }
    }
}
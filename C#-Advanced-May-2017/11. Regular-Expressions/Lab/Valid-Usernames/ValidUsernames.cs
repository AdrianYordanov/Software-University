using System;
using System.Text.RegularExpressions;

public class ValidUsernames
{
    private static void Main()
    {
        var regex = new Regex("^[a-zA-Z0-9_-]{3,16}$");
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            Console.WriteLine(regex.IsMatch(input) ? "valid" : "invalid");
        }
    }
}
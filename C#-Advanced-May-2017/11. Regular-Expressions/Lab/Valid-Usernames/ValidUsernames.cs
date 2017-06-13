using System;
using System.Text.RegularExpressions;

class ValidUsernames
{
    static void Main()
    {
        var regex = new Regex("^[a-zA-Z0-9_-]{3,16}$");
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "END")
        {
            Console.WriteLine(regex.IsMatch(input) ? "valid" : "invalid");
        }
    }
}
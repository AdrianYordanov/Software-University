using System;
using System.Text.RegularExpressions;

class ValidTime
{
    static void Main()
    {
        var regex = new Regex("(?<hours>[01][0-9]):(?<minutes>[0-6][0-9]):(?<seconds>[0-6][0-9]) (A|P)M");
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "END")
        {
            Console.WriteLine(regex.IsMatch(input) && IsValidHour(regex.Match(input).Groups["hours"].ToString()) ? "valid" : "invalid");
        }
    }

    private static bool IsValidHour(string hourToString)
    {
        var hour = int.Parse(hourToString);
        return hour <= 12;
    }
}
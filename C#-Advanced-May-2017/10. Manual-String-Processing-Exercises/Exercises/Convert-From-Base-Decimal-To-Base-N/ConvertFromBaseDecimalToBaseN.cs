using System;
using System.Numerics;

public class ConvertFromBaseDecimalToBaseN
{
    private static void Main()
    {
        var tokens = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        var baseSystem = int.Parse(tokens[0]);
        var decimalNumber = BigInteger.Parse(tokens[1]);
        var result = string.Empty;
        while (decimalNumber > 0)
        {
            var remainder = decimalNumber % baseSystem;
            decimalNumber = decimalNumber / baseSystem;
            result = remainder + result;
        }

        Console.WriteLine(result == string.Empty ? "0" : result);
    }
}
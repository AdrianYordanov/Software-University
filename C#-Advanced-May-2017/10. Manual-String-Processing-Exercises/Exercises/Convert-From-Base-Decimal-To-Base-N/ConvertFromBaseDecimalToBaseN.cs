using System;
using System.Numerics;

class ConvertFromBaseDecimalToBaseN
{
    static void Main()
    {
        var tokens = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        var nBase = int.Parse(tokens[0]);
        var decimalNumber = BigInteger.Parse(tokens[1]);
        var result = string.Empty;

        while (decimalNumber > 0)
        {
            var remainder = decimalNumber % nBase;
            decimalNumber = decimalNumber / nBase;
            result = remainder + result;
        }

        Console.WriteLine(result == string.Empty ? "0" : result);
    }
}
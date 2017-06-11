using System;
using System.Numerics;

class ConvertFromBaseNToBaseDecimal
{
    static void Main()
    {
        var tokens = Console.ReadLine().Split(' ');
        var nBase = int.Parse(tokens[0]);
        BigInteger result = 0;

        for (int i = tokens[1].Length - 1, degree = 0; i >= 0; i--, degree++)
        {
            result += int.Parse(tokens[1][i].ToString()) * BigInteger.Pow(nBase, degree);
        }

        Console.WriteLine(result);
    }
}
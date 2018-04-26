﻿using System;
using System.Numerics;

public class ConvertFromBaseNToBaseDecimal
{
    private static void Main()
    {
        var tokens = Console.ReadLine().Split(' ');
        var baseSystem = int.Parse(tokens[0]);
        BigInteger result = 0;
        for (int i = tokens[1].Length - 1, degree = 0; i >= 0; i--, degree++)
        {
            result += int.Parse(tokens[1][i].ToString()) * BigInteger.Pow(baseSystem, degree);
        }

        Console.WriteLine(result);
    }
}
﻿using System;
using System.Text.RegularExpressions;

class NonDigitCount
{
    static void Main()
    {
        var text = Console.ReadLine();
        var regex = new Regex(@"[^0-9]");
        var count = regex.Matches(text).Count;
        Console.WriteLine($"Non-digits: {count}");
    }
}
﻿using System;

class ActionPrint
{
    static void Main()
    {
        Action<string> print = (inputString) =>
        {
            var collection = inputString.Split(' ');
            Console.WriteLine(string.Join(Environment.NewLine, collection));
        };

        print(Console.ReadLine());
    }
}
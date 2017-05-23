using System;
using System.Collections.Generic;

class ReverseStrings
{
    static void Main()
    {
        var input = Console.ReadLine();
        var stack = new Stack<char>();

        for (int i = 0; i < input.Length; i++)
        {
            stack.Push(input[i]);
        }

        for (int i = 0; stack.Count > 0; i++)
        {
            Console.Write(stack.Pop());
        }

        Console.WriteLine();
    }
}
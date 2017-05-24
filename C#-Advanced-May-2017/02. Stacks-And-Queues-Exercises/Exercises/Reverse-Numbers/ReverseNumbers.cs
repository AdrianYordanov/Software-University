using System;
using System.Collections.Generic;

class ReverseNumbers
{
    static void Main()
    {
        var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var stack = new Stack<int>();

        for (int i = 0; i < tokens.Length; i++)
        {
            stack.Push(int.Parse(tokens[i]));
        }

        while (stack.Count > 0)
        {
            Console.Write(stack.Pop() + " ");
        }

        Console.WriteLine();
    }
}
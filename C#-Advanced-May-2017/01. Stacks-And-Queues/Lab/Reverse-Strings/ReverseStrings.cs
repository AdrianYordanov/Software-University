using System;
using System.Collections.Generic;

public class ReverseStrings
{
    public static void Main()
    {
        var input = Console.ReadLine();
        var stack = new Stack<char>();

        foreach (var character in input)
        {
            stack.Push(character);
        }

        while (stack.Count > 0)
        {
            Console.Write(stack.Pop());
        }

        Console.WriteLine();
    }
}
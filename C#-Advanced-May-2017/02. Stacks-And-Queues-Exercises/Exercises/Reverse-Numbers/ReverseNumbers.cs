using System;
using System.Collections.Generic;

public class ReverseNumbers
{
    public static void Main()
    {
        var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var stack = new Stack<int>();
        foreach (var currentString in tokens)
        {
            stack.Push(int.Parse(currentString));
        }

        while (stack.Count > 0)
        {
            Console.Write(stack.Pop() + " ");
        }

        Console.WriteLine();
    }
}
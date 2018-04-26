using System;
using System.Collections.Generic;

public class SimpleCalculator
{
    private static void Main()
    {
        var input = Console.ReadLine();
        var tokens = input.Split(' ');
        var stack = new Stack<double>();
        for (var i = 0; i < tokens.Length; i++)
        {
            if (stack.Count == 0)
            {
                stack.Push(double.Parse(tokens[i]));
            }
            else
            {
                var operation = tokens[i++];
                if (operation == "+")
                {
                    stack.Push(stack.Pop() + double.Parse(tokens[i]));
                }
                else if (operation == "-")
                {
                    stack.Push(stack.Pop() - double.Parse(tokens[i]));
                }
            }
        }

        Console.WriteLine(stack.Pop());
    }
}
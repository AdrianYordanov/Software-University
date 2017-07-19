using System;
using System.Collections.Generic;

public class MatchingBrackets
{
    public static void Main()
    {
        var input = Console.ReadLine();
        var stack = new Stack<int>();
        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                stack.Push(i);
            }

            if (input[i] != ')')
            {
                continue;
            }

            var lastScopeIndexOpen = stack.Pop();
            Console.WriteLine(input.Substring(lastScopeIndexOpen, i - lastScopeIndexOpen + 1));
        }
    }
}
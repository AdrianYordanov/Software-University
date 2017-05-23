using System;
using System.Collections.Generic;

class MatchingBrackets
{
    static void Main()
    {
        var input = Console.ReadLine();
        var stack = new Stack<int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                stack.Push(i);
            }

            if (input[i] == ')')
            {
                var lastScopeIndexOpen = stack.Pop();
                Console.WriteLine(input.Substring(lastScopeIndexOpen, i - lastScopeIndexOpen + 1));
            }
        }
    }
}

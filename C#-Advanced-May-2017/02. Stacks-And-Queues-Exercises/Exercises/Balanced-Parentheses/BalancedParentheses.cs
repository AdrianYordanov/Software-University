using System;
using System.Collections.Generic;
using System.Linq;

public class BalancedParentheses
{
    private static void Main()
    {
        var input = Console.ReadLine();
        var stack = new Stack<char>();
        var openBrackets = new[] { '{', '[', '(' };
        var isBalanced = true;
        foreach (var currentBracket in input)
        {
            if (openBrackets.Contains(currentBracket))
            {
                stack.Push(currentBracket);
            }
            else
            {
                if (stack.Count == 0)
                {
                    isBalanced = false;
                    break;
                }

                var lastOpenBracket = stack.Pop();
                switch (currentBracket)
                {
                    case '}':
                        if (lastOpenBracket != '{')
                        {
                            isBalanced = false;
                        }

                        break;
                    case ']':
                        if (lastOpenBracket != '[')
                        {
                            isBalanced = false;
                        }

                        break;
                    case ')':
                        if (lastOpenBracket != '(')
                        {
                            isBalanced = false;
                        }

                        break;
                }

                if (!isBalanced)
                {
                    break;
                }
            }
        }

        Console.WriteLine(isBalanced ? "YES" : "NO");
    }
}
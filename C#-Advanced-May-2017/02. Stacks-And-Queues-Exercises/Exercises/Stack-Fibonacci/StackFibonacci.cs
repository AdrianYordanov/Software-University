using System;
using System.Collections.Generic;

public class StackFibonacci
{
    private static void Main()
    {
        var n = ulong.Parse(Console.ReadLine());
        var stack = new Stack<ulong>(new ulong[] { 0, 1 });
        for (var i = 2UL; i <= n; i++)
        {
            var last = stack.Pop();
            var beforeLast = stack.Pop();
            var current = last + beforeLast;
            stack.Push(beforeLast);
            stack.Push(last);
            stack.Push(current);
        }

        Console.WriteLine(stack.Peek());
    }
}
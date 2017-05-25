using System;
using System.Collections.Generic;

class StackFibonacci
{
    static void Main()
    {
        var n = ulong.Parse(Console.ReadLine());
        var stack = new Stack<ulong>(new ulong[] { 0, 1 });

        for (ulong i = 2; i <= n; i++)
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
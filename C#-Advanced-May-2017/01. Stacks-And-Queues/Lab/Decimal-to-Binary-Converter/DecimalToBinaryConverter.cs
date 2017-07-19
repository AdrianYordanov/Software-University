using System;
using System.Collections.Generic;

public class DecimalToBinaryConverter
{
    public static void Main()
    {
        var number = int.Parse(Console.ReadLine());
        var stack = new Stack<int>();

        if (number == 0)
        {
            Console.WriteLine(number);
            return;
        }

        while (number > 0)
        {
            stack.Push(number % 2 == 0 ? 0 : 1);
            number /= 2;
        }

        while (stack.Count > 0)
        {
            Console.Write(stack.Pop());
        }

        Console.WriteLine();
    }
}
using System;
using System.Collections.Generic;

class DecimalToBinaryConverter
{
    static void Main()
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
            if (number % 2 == 0)
            {
                stack.Push(0);
            }
            else
            {
                stack.Push(1);
            }

            number /= 2;
        }

        while (stack.Count > 0)
        {
            Console.Write(stack.Pop());
        }

        Console.WriteLine();
    }
}
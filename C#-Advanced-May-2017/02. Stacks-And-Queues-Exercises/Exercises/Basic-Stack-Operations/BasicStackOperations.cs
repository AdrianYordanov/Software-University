using System;
using System.Collections.Generic;

public class BasicStackOperations
{
    public static void Main()
    {
        var tokens = Console.ReadLine()
            .Split(' ');
        var numbers = Console.ReadLine()
            .Split(' ');
        var stack = new Stack<int>();
        var n = int.Parse(tokens[0]);
        var s = int.Parse(tokens[1]);
        var x = int.Parse(tokens[2]);
        for (var pushElementCounter = 0; pushElementCounter < n; pushElementCounter++)
        {
            stack.Push(int.Parse(numbers[pushElementCounter]));
        }

        for (var popElementsCounter = 0; popElementsCounter < s; popElementsCounter++)
        {
            stack.Pop();
        }

        var stackCount = stack.Count;
        var isFoundX = false;
        var smallestNumber = int.MaxValue;
        while (stack.Count > 0)
        {
            var popNumber = stack.Pop();
            if (popNumber == x)
            {
                isFoundX = true;
            }
            else if (smallestNumber > popNumber)
            {
                smallestNumber = popNumber;
            }
        }

        if (stackCount == 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            if (isFoundX)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(smallestNumber);
            }
        }
    }
}
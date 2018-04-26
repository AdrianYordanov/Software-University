using System;
using System.Collections.Generic;
using System.Linq;

public class PoisonousPlants
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var plants = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var days = new int[n];
        var proximityStack = new Stack<int>();
        proximityStack.Push(0);
        for (var i = 0; i < plants.Length; i++)
        {
            var maxDays = 0;
            while (proximityStack.Count > 0
                   && plants[proximityStack.Peek()] >= plants[i])
            {
                maxDays = Math.Max(maxDays, days[proximityStack.Pop()]);
            }

            if (proximityStack.Count > 0)
            {
                days[i] = maxDays + 1;
            }

            proximityStack.Push(i);
        }

        Console.WriteLine(days.Max());
    }
}
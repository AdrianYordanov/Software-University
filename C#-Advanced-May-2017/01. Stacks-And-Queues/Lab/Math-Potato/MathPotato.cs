﻿using System;
using System.Collections.Generic;

public class MathPotato
{
    private static bool IsPrime(int candidate)
    {
        if ((candidate & 1) == 0)
        {
            return candidate == 2;
        }

        for (var i = 3; (i * i) <= candidate; i += 2)
        {
            if (candidate % i == 0)
            {
                return false;
            }
        }

        return candidate != 1;
    }

    private static void Main()
    {
        var names = Console.ReadLine().Split(' ');
        var n = int.Parse(Console.ReadLine());
        var queue = new Queue<string>(names);
        var cycles = 1;
        while (queue.Count > 1)
        {
            for (var i = 0; i < (n - 1); i++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            Console.WriteLine(IsPrime(cycles) ? $"Prime {queue.Peek()}" : $"Removed {queue.Dequeue()}");
            cycles++;
        }

        Console.WriteLine($"Last is {queue.Dequeue()}");
    }
}
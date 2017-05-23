using System;
using System.Collections.Generic;

class MathPotato
{
    static void Main()
    {
        var names = Console.ReadLine().Split(' ');
        var n = int.Parse(Console.ReadLine());
        var queue = new Queue<string>(names);
        var cycles = 1;

        while (queue.Count > 1)
        {
            for (int i = 0; i < n - 1; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            if (IsPrime(cycles))
            {
                Console.WriteLine($"Prime {queue.Peek()}");
            }
            else
            {
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            cycles++;
        }

        Console.WriteLine($"Last is {queue.Dequeue()}");
    }

    public static bool IsPrime(int candidate)
    {
        if ((candidate & 1) == 0)
        {
            if (candidate == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        for (int i = 3; (i * i) <= candidate; i += 2)
        {
            if ((candidate % i) == 0)
            {
                return false;
            }
        }
        return candidate != 1;
    }
}
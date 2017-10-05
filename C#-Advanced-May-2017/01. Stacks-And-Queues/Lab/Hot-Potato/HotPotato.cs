using System;
using System.Collections.Generic;

public class HotPotato
{
    public static void Main()
    {
        var names = Console.ReadLine()
            .Split(' ');
        var n = int.Parse(Console.ReadLine());
        var queue = new Queue<string>(names);
        while (queue.Count > 1)
        {
            for (var i = 0; i < n - 1; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            Console.WriteLine($"Removed {queue.Dequeue()}");
        }

        Console.WriteLine($"Last is {queue.Dequeue()}");
    }
}
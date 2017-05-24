using System;
using System.Collections.Generic;

class CalculateSequenceWithQueue
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        long membersCount = 50;
        var queue = new Queue<long>();

        queue.Enqueue(n);

        for (int i = 0; i < membersCount; i++)
        {
            var currentS = queue.Dequeue();
            Console.Write(currentS + " ");
            queue.Enqueue(currentS + 1);
            queue.Enqueue(currentS * 2 + 1);
            queue.Enqueue(currentS + 2);
        }
    }
}
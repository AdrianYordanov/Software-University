using System;
using System.Collections.Generic;

public class CalculateSequenceWithQueue
{
    public static void Main()
    {
        var n = long.Parse(Console.ReadLine());
        var membersCount = 50L;
        var queue = new Queue<long>();
        queue.Enqueue(n);
        for (var i = 0; i < membersCount; i++)
        {
            var currentS = queue.Dequeue();
            Console.Write(currentS + " ");
            queue.Enqueue(currentS + 1);
            queue.Enqueue((currentS * 2) + 1);
            queue.Enqueue(currentS + 2);
        }
    }
}
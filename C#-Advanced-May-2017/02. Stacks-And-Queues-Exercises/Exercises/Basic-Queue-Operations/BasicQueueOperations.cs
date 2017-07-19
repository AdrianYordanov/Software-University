using System;
using System.Collections.Generic;

public class BasicQueueOperations
{
    public static void Main()
    {
        var tokens = Console.ReadLine().Split(' ');
        var numbers = Console.ReadLine().Split(' ');
        var queue = new Queue<int>();
        var n = int.Parse(tokens[0]);
        var s = int.Parse(tokens[1]);
        var x = int.Parse(tokens[2]);

        for (var enqueueElementCounter = 0; enqueueElementCounter < n; enqueueElementCounter++)
        {
            queue.Enqueue(int.Parse(numbers[enqueueElementCounter]));
        }

        for (var dequeueElementsCounter = 0; dequeueElementsCounter < s; dequeueElementsCounter++)
        {
            queue.Dequeue();
        }

        var queueCount = queue.Count;
        var isFoundX = false;
        var smallestNumber = int.MaxValue;

        while (queue.Count > 0)
        {
            var enqueueNumber = queue.Dequeue();

            if (enqueueNumber == x)
            {
                isFoundX = true;
            }
            else if (smallestNumber > enqueueNumber)
            {
                smallestNumber = enqueueNumber;
            }
        }

        if (queueCount == 0)
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
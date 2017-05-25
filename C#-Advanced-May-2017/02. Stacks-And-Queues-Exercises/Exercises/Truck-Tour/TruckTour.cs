using System;
using System.Collections.Generic;
using System.Linq;

class TruckTour
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var circle = new Queue<long[]>();

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToArray();
            circle.Enqueue(tokens);
        }

        int startIndex = 0;
        long tankFuel = 0;

        for (; startIndex < circle.Count; ++startIndex)
        {
            // Now we start and try to go to the next pump.
            bool shouldBreak = true;
            var currentPump = circle.Dequeue();
            circle.Enqueue(currentPump);
            tankFuel = currentPump[0] - currentPump[1];

            if (tankFuel < 0)
            {
                // We dont have fuel.
                continue;
            }

            for (int itteration = 0; itteration < circle.Count; itteration++)
            {
                currentPump = circle.Dequeue();
                circle.Enqueue(currentPump);
                tankFuel += currentPump[0];
                tankFuel -= currentPump[1];

                if (tankFuel < 0)
                {
                    shouldBreak = false;
                }
            }

            if (shouldBreak)
            {
                // We found the right route.
                break;
            }
        }

        Console.WriteLine(startIndex);
    }
}
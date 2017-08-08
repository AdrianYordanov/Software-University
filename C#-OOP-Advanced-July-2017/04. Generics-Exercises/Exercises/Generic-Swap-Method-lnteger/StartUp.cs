using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var boxes = new List<Box>();
        var n = int.Parse(Console.ReadLine());
        for (var i = 0; i < n; i++)
        {
            boxes.Add(new Box(int.Parse(Console.ReadLine())));
        }

        var swapTokens = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        Swapper.Swap(boxes, swapTokens[0], swapTokens[1]);
        foreach (var box in boxes)
        {
            Console.WriteLine(box);
        }
    }
}
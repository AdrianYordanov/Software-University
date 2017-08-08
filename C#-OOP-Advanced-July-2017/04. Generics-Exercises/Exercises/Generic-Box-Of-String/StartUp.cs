using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var boxes = new List<Box>();
        var n = int.Parse(Console.ReadLine());
        for (var i = 0; i < n; i++)
        {
            boxes.Add(new Box(Console.ReadLine()));
        }

        foreach (var box in boxes)
        {
            Console.WriteLine(box);
        }
    }
}
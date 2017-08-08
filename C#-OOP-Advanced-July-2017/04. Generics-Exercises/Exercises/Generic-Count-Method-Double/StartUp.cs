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
            boxes.Add(new Box(double.Parse(Console.ReadLine())));
        }

        var compareElement = new Box(double.Parse(Console.ReadLine()));
        var greaterElementsCount = GetGreaterElementsCount(boxes, compareElement);
        Console.WriteLine(greaterElementsCount);
    }

    public static int GetGreaterElementsCount<T>(IList<T> collection, T compareElement) where T : Box
    {
        var counter = 0;
        foreach (var element in collection)
        {
            if (element.CompareTo(compareElement) > 0)
            {
                ++counter;
            }
        }

        return counter;
    }
}
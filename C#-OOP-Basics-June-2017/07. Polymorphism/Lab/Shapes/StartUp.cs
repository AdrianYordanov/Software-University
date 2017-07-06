using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        var shapes = new List<Shape>();
        shapes.Add(new Rectangle(3, 4));
        shapes.Add(new Circle(120.34));

        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.Draw()}, area: {shape.CalculateArea():f2} perimeter: {shape.CalculatePerimeter():f2}");
        }
    }
}
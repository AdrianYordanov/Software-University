using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static void Main()
    {
        var input = Console.ReadLine();
        var rectanglesCount = int.Parse(input.Split(' ')[0]);
        var checksCount = int.Parse(input.Split(' ')[1]);
        var rectangles = new List<Rectangle>();
        for (var i = 0; i < rectanglesCount; i++)
        {
            var tokens = Console.ReadLine().Split(' ');
            var id = tokens[0];
            var width = double.Parse(tokens[1]);
            var height = double.Parse(tokens[2]);
            var x = double.Parse(tokens[3]);
            var y = double.Parse(tokens[4]);
            rectangles.Add(new Rectangle(id, width, height, x, y));
        }

        for (var i = 0; i < checksCount; i++)
        {
            var tokens = Console.ReadLine().Split(' ');
            var firstRectangle = rectangles.First(rectangle => rectangle.Id == tokens[0]);
            var secondRectangle = rectangles.First(rectangle => rectangle.Id == tokens[1]);
            Console.WriteLine(firstRectangle.IsIntersect(secondRectangle).ToString().ToLower());
        }
    }
}
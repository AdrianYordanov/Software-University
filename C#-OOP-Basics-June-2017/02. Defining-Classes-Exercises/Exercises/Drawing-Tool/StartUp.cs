using System;

public class StartUp
{
    private static void Main()
    {
        var input = Console.ReadLine();
        if (input == "Square")
        {
            var side = int.Parse(Console.ReadLine());

            // ReSharper disable once ObjectCreationAsStatement
            new CorDraw(new Square(side));
        }
        else if (input == "Rectangle")
        {
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());

            // ReSharper disable once ObjectCreationAsStatement
            new CorDraw(new Rectangle(width, height));
        }
    }
}
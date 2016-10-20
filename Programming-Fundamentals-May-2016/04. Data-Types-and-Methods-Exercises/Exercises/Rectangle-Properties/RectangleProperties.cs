using System;

class RectangleProperties
{
    static void Main()
    {
        double width = double.Parse(Console.ReadLine());
        double heigth = double.Parse(Console.ReadLine());

        double perimeter = width * 2 + heigth * 2;
        double area = width * heigth;
        double diagonal = Math.Sqrt(width * width + heigth * heigth);

        Console.WriteLine(perimeter);
        Console.WriteLine(area);
        Console.WriteLine(diagonal);
    }
}
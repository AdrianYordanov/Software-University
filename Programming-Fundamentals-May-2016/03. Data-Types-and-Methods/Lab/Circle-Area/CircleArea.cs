using System;

class CircleArea
{
    static void Main()
    {
        double r = double.Parse(Console.ReadLine());
        Console.WriteLine("{0:f12}", Math.PI * r * r);
    }
}
using System;
using System.Linq;

class RoundingAwayFromZero
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split(' ')
            .Select(double.Parse)
            .ToArray();

        for (int i = 0; i < array.Length; i++)
        {
            var rounded = Math.Round(array[i], MidpointRounding.AwayFromZero);
            Console.WriteLine("{0} => {1}", array[i], rounded);
        }
    }
}
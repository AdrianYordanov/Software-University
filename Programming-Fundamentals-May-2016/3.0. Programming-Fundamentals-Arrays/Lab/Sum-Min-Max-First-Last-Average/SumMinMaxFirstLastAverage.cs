using System;
using System.Linq;

class SumMinMaxFirstLastAverage
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var array = new int[n];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Sum = " + array.Sum());
        Console.WriteLine("Min = " + array.Min());
        Console.WriteLine("Max = " + array.Max());
        Console.WriteLine("First = " + array.First());
        Console.WriteLine("Last = " + array.Last());
        Console.WriteLine("Average = " + array.Average());
    }
}
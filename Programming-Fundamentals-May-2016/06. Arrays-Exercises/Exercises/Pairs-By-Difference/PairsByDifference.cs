using System;
using System.Linq;

class PairsByDifference
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        var number = int.Parse(Console.ReadLine());

        int count = 0;

        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                var min = Math.Min(array[i], array[j]);
                var max = Math.Max(array[i], array[j]);

                if((max - min) == number)
                {
                    ++count;
                }
            }
        }

        Console.WriteLine(count);
    }
}
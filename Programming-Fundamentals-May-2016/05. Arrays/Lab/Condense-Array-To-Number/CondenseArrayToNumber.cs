using System;
using System.Linq;

class CondenseArrayToNumber
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split(' ')
            .Select(long.Parse)
            .ToArray();

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                array[j] += array[j + 1];
            }
        }

        Console.WriteLine(array[0]);
    }
}
using System;
using System.Linq;

class SumArrays
{
    static void Main()
    {
        var firstArray = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        var secondArray = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var biggerLength = Math.Max(firstArray.Length, secondArray.Length);
        var thirdArray = new long[biggerLength];

        for (int i = 0; i < thirdArray.Length; i++)
        {
           thirdArray[i] = firstArray[i % firstArray.Length] +
                secondArray[i % secondArray.Length];
        }

        Console.WriteLine(string.Join(" ", thirdArray));
    }
}
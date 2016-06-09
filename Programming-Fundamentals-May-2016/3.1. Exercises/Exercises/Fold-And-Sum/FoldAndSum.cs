using System;
using System.Linq;

class FoldAndSum
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int partsLength = array.Length / 4;

        var leftPart = array
            .Take(partsLength)
            .Reverse()
            .ToArray();
        var rightPart = array
            .Skip(array.Length - partsLength)
            .Take(partsLength)
            .Reverse()
            .ToArray();
        var middlePart = array
            .Skip(partsLength)
            .Take(array.Length - (2 * partsLength))
            .ToArray();
        var concatenatedArray = new int[leftPart.Length + rightPart.Length];

        leftPart.CopyTo(concatenatedArray, 0);
        rightPart.CopyTo(concatenatedArray, leftPart.Length);

        for (int i = 0; i < middlePart.Length; i++)
        {
            middlePart[i] += concatenatedArray[i];
        }

        Console.WriteLine(string.Join(" ", middlePart));
    }
}
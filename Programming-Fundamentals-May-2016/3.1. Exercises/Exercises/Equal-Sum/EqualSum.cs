using System;
using System.Linq;

class EqualSum
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        bool foundSum = false;

        for (int i = 0; i < array.Length; i++)
        {
            var leftSum = CalcSumToLeft(array, i);
            var rightSum = CalcSumToRight(array, i);

            if (leftSum == rightSum)
            {
                Console.WriteLine(i);
                foundSum = true;
                break;
            }
        }

        if (!foundSum)
        {
            Console.WriteLine("no");
        }
    }

    static int CalcSumToLeft(int[] array, int startIndex)
    {
        int sum = 0;

        for (int i = startIndex - 1; i >= 0; i--)
        {
            sum += array[i];
        }

        return sum;
    }

    static int CalcSumToRight(int[] array, int startIndex)
    {
        int sum = 0;

        for (int i = startIndex + 1; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum;
    }
}
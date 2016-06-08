using System;
using System.Linq;

class RotateAndSum
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var k = int.Parse(Console.ReadLine());
        var sum = new int[array.Length];

        for (int rotations = 1; rotations <= k; rotations++)
        {
            Rotate(array);

            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] += array[i];
            }
        }

        Console.WriteLine(string.Join(" ", sum));
    }

    private static void Rotate(int[] array)
    {
        if (array != null && array.Length > 0)
        {
            int temp = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                int nestedTemp = array[i];
                array[i] = temp;
                temp = nestedTemp;
            }

            array[0] = temp;
        }
    }
}
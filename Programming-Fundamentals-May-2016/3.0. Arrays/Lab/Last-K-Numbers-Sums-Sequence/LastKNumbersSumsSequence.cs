using System;

class LastKNumbersSumsSequence
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var k = int.Parse(Console.ReadLine());

        var array = new long[n];
        array[0] = 1;

        for (int i = 1; i < array.Length; i++)
        {
            if (i - k >= 0)
            {
                array[i] = GetSum(array, i - k, i - 1);
            }
            else
            {
                if (i == 1)
                {
                    array[i] = 1;
                }
                else
                {
                    array[i] = array[i - 1] * 2;
                }
            }
        }

        Console.WriteLine(string.Join(" ", array));
    }

    private static long GetSum(long[] array, int startIndex, int endIndex)
    {
        long sum = 0;

        for (int i = startIndex; i <= endIndex; i++)
        {
            sum += array[i];
        }

        return sum;
    }
}
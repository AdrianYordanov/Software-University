using System;
using System.Linq;

class MaxSequenceOfIncreasingElements
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int currentLength = 1,
            maxLength = 1,
            currentStartIndex = 0,
            maxLengthIndex = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[i - 1])
            {
                ++currentLength;
            }
            else
            {
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxLengthIndex = currentStartIndex;
                }

                currentLength = 1;
                currentStartIndex = i;
            }
        }

        if (currentLength > maxLength)
        {
            maxLength = currentLength;
            maxLengthIndex = currentStartIndex;
        }

        for (int i = maxLengthIndex; i < maxLengthIndex + maxLength; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}
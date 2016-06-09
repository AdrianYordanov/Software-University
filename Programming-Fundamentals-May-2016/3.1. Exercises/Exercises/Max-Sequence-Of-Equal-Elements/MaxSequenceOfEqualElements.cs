using System;
using System.Linq;

class MaxSequenceOfEqualElements
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int currentLength = 1,
            maxLength = 1,
            maxLengthIndex = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i].Equals(array[i - 1]))
            {
                ++currentLength;
            }
            else
            {
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxLengthIndex = i - 1;
                }

                currentLength = 1;
            }
        }

        if (currentLength > maxLength)
        {
            maxLength = currentLength;
            maxLengthIndex = array.Length - 1;
        }

        for (int i = 0; i < maxLength; i++)
        {
            Console.Write(array[maxLengthIndex] + " ");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

class MaxSequenceOfEqualNumbers
{
    static void Main()
    {
        var list = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        int currentStartIndex = 0,
            bestStartIndex = 0,
            currentLength = 1,
            bestLength = 1;

        for (int i = 1; i < list.Count; i++)
        {
            bool setDefaultCurrentLengh = false;

            if (list[i].Equals(list[i - 1]))
            {
                if (currentLength == 1)
                {
                    currentStartIndex = i - 1;
                }
                ++currentLength;
            }
            else
            {
                setDefaultCurrentLengh = true;
            }

            if (currentLength > bestLength)
            {
                bestLength = currentLength;
                bestStartIndex = currentStartIndex;
            }

            if (setDefaultCurrentLengh)
            {
                currentLength = 1;
            }
        }

        Console.WriteLine(string.Join(" ", list.GetRange(bestStartIndex, bestLength)));
    }
}
using System;
using System.Linq;

class LargestCommonEnd
{
    static void Main()
    {
        string[] firstArray = Console.ReadLine()
            .Split(' ');
        string[] secondArray = Console.ReadLine()
            .Split(' ');

        int bestLengthToRigth = GetBestLengthByScanArrays(firstArray, secondArray);
        firstArray = firstArray.Reverse().ToArray();
        secondArray = secondArray.Reverse().ToArray();
        int bestLengthToLeft = GetBestLengthByScanArrays(firstArray, secondArray);

        Console.WriteLine(bestLengthToRigth > bestLengthToLeft ? bestLengthToRigth.ToString() : bestLengthToLeft.ToString());
    }

    private static int GetBestLengthByScanArrays(string[] firstArray, string[] secondArray)
    {
        int bestLength = 0,
            currentLength = 0,
            minLength = Math.Min(firstArray.Length, secondArray.Length);

        for (int index = 0; index < minLength; index++)
        {
            if (firstArray[index].Equals(secondArray[index]))
            {
                ++currentLength;
                bestLength = Math.Max(currentLength, bestLength);
            }
            else
            {
                currentLength = 0;
            }
        }

        return bestLength;
    }
}
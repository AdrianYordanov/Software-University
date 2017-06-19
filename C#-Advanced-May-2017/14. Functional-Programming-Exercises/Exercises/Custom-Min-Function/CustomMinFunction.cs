using System;
using System.Linq;

class CustomMinFunction
{
    static void Main()
    {
        Func<int[], int> customMinFunc = (numArray) =>
        {
            var min = int.MaxValue;

            for (int i = 0; i < numArray.Length; i++)
            {
                if (min > numArray[i])
                {
                    min = numArray[i];
                }
            }

            return min;
        };

        var input = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        Console.WriteLine(customMinFunc(input));
    }
}
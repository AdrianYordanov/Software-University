using System;
using System.Linq;

public class CustomMinFunction
{
    private static void Main()
    {
        Func<int[], int> customMinFunc = numArray =>
        {
            var min = int.MaxValue;
            for (var i = 0; i < numArray.Length; i++)
            {
                if (min > numArray[i])
                {
                    min = numArray[i];
                }
            }

            return min;
        };
        var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.WriteLine(customMinFunc(input));
    }
}
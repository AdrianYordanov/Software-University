using System;
using System.Linq;

class Numbers
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        Array.Sort(array);

        decimal average = (array.Sum() + 0.0m) / array.Length;
        int count = 0;

        for (int i = array.Length - 1; i >= 0; i--)
        {
            if(array[i] > average && count < 5)
            {
                ++count;
                Console.Write(array[i] + " ");
            }
        }

        if(count == 0)
        {
            Console.WriteLine("No");
        }
    }
}
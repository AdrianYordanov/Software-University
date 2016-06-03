using System;
using System.Linq;

class TripleSum
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        bool triplesFound = false;

        for (int a = 0; a < array.Length - 1; a++)
        {
            for (int b = a + 1; b < array.Length; b++)
            {
                int aValue = array[a];
                int bValue = array[b];

                if (array.Contains(aValue + bValue))
                {
                    triplesFound = true;
                    Console.WriteLine("{0} + {1} == {2}", aValue, bValue, aValue + bValue);
                }
            }
        }

        if(!triplesFound)
        {
            Console.WriteLine("No");
        }
    }
}

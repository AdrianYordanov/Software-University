using System;
using System.Linq;

class ExtractMiddleElement
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        PrintMiddleElements(array);
    }

    private static void PrintMiddleElements(int[] array)
    {
        if (array.Length == 1)
        {
            Console.WriteLine("{{ {0} }}", array[0]);
        }
        else
        {
            var middle = array.Length / 2;

            if(array.Length % 2 == 0)
            {
                Console.WriteLine("{{ {0}, {1} }}", array[middle - 1], array[middle]);
            }
            else
            {
                Console.WriteLine("{{ {0}, {1}, {2} }}", array[middle - 1], array[middle], array[middle+1]);
            }
        }
    }
}
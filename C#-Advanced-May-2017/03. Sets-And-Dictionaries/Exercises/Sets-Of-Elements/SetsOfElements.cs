using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SetsOfElements
{
    static void Main()
    {
        var tokens = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        var firstSet = new HashSet<int>();
        var secondSet = new HashSet<int>();

        for (int i = 0; i < tokens[0]; i++)
        {
            var number = int.Parse(Console.ReadLine());
            firstSet.Add(number);
        }

        for (int i = 0; i < tokens[1]; i++)
        {
            var number = int.Parse(Console.ReadLine());
            secondSet.Add(number);
        }

        foreach (var item in firstSet)
        {
            if (secondSet.Contains(item))
            {
                Console.Write(item + " ");
            }
        }
    }
}
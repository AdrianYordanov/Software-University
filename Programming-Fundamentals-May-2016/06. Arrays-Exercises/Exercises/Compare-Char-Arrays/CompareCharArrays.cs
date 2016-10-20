using System;
using System.Linq;

class CompareCharArrays
{
    static void Main()
    {
        var firstLine = Console.ReadLine()
            .Split(' ')
            .Select(char.Parse)
            .ToArray();
        var secondLine = Console.ReadLine()
            .Split(' ')
            .Select(char.Parse)
            .ToArray();

        bool equal = true;
        int minLength = Math.Min(firstLine.Length, secondLine.Length);

        for (int i = 0; i < minLength; i++)
        {
            if (firstLine[i].Equals(secondLine[i]))
            {
                continue;
            }

            equal = false;

            if (firstLine[i].CompareTo(secondLine[i]) > 0)
            {
                Console.WriteLine(string.Join("", secondLine));
                Console.WriteLine(string.Join("", firstLine));
                break;
            }
            else
            {
                Console.WriteLine(string.Join("", firstLine));
                Console.WriteLine(string.Join("", secondLine));
                break;
            }
        }

        if(equal)
        {
            if(firstLine.Length > secondLine.Length)
            {
                Console.WriteLine(string.Join("", secondLine));
                Console.WriteLine(string.Join("", firstLine));
            }
            else
            {
                Console.WriteLine(string.Join("", firstLine));
                Console.WriteLine(string.Join("", secondLine));
            }
        }
    }
}
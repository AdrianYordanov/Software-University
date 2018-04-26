using System;
using System.Collections.Generic;
using System.Linq;

public class CustomComparator
{
    private static void Main()
    {
        var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var evenOddComparator = new EvenOddComparer();
        Array.Sort(numbers, evenOddComparator);
        Console.WriteLine(string.Join(" ", numbers));
    }

    private class EvenOddComparer : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            if (this.IsEven(a)
                && !this.IsEven(b))
            {
                return -1;
            }

            if (!this.IsEven(a)
                && this.IsEven(b))
            {
                return 1;
            }

            if (a >= b)
            {
                return 1;
            }

            return -1;
        }

        private bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

class MaximumElement
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var stack = new Stack<int>();
        var maxNumbers = new Stack<int>();
        var maxElement = int.MinValue;

        for (int i = 0; i < n; i++)
        {
            var query = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            switch (query[0])
            {
                case 1:
                    {
                        var pushValue = query[1];
                        stack.Push(pushValue);

                        if (pushValue > maxElement)
                        {
                            maxElement = pushValue;
                            maxNumbers.Push(maxElement);
                        }

                        break;
                    }
                case 2:
                    {
                        if (stack.Count == 0)
                        {
                            break;
                        }

                        var removeNumber = stack.Pop();

                        if (removeNumber == maxElement)
                        {
                            maxNumbers.Pop();

                            if (maxNumbers.Count > 0)
                            {
                                maxElement = maxNumbers.Peek();
                            }
                            else
                            {
                                maxElement = int.MinValue;
                            }
                        }

                        break;
                    }
                case 3:
                    {
                        Console.WriteLine(maxElement);
                        break;
                    }
            }
        }
    }
}
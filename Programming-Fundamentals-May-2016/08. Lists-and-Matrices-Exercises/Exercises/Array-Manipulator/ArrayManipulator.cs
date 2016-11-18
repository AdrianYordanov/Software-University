using System;
using System.Collections.Generic;
using System.Linq;

class ArrayManipulator
{
    static void Main()
    {
        var list = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();
        var line = Console.ReadLine();

        while (!string.IsNullOrEmpty(line))
        {
            var tokens = line.Split(' ');

            switch (tokens[0])
            {
                case "add":
                    {
                        Add(int.Parse(tokens[1]), int.Parse(tokens[2]), list);
                        break;
                    }
                case "addMany":
                    {
                        AddMany(int.Parse(tokens[1]), tokens.Skip(2).Select(int.Parse).ToArray(), list);
                        break;
                    }
                case "contains":
                    {
                        Contains(int.Parse(tokens[1]), list);
                        break;
                    }
                case "remove":
                    {
                        Remove(int.Parse(tokens[1]), list);
                        break;
                    }
                case "shift":
                    {
                        Shift(int.Parse(tokens[1]), list);
                        break;
                    }
                case "sumPairs":
                    {
                        SumPairs(list);
                        break;
                    }
                case "print":
                    {
                        Print(list);
                        break;
                    }
            }

            line = Console.ReadLine();
        }
    }

    static void Add(int index, int element, List<int> list)
    {
        list.Insert(index, element);
    }

    static void Remove(int index, List<int> list)
    {
        list.RemoveAt(index);
    }

    static void Contains(int number, List<int> list)
    {
        var result = list.IndexOf(number);
        Console.WriteLine(result);
    }

    static void AddMany(int index, int[] array, List<int> list)
    {
        if (index == list.Count)
        {
            list.AddRange(array);
        }
        else
        {
            foreach (var number in array.Reverse())
            {
                Add(index, number, list);
            }
        }
    }

    static void Shift(int times, List<int> list)
    {
        for (int i = 0; i < times; i++)
        {
            var firstElement = list.ElementAt(0);
            Remove(0, list);
            list.Add(firstElement);
        }
    }

    static void SumPairs(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (i + 1 < list.Count)
            {
                list[i] += list[i + 1];
                Remove(i + 1, list);
            }
        }
    }

    static void Print(List<int> list)
    {
        Console.WriteLine("[" + string.Join(", ", list) + "]");
    }
}
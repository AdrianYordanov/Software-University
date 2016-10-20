using System;
using System.Linq;

public class SequenceOfCommands
{
    private const char ArgumentsDelimiter = ' ';

    public static void Main()
    {
        int sizeOfArray = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine()
            .Split(ArgumentsDelimiter)
            .Select(long.Parse)
            .ToArray();

        string line = Console.ReadLine().Trim();

        while (!line.Equals("stop"))
        {
            var lineParams = line.Split(ArgumentsDelimiter);
            var command = lineParams[0];
            var args = new int[2];

            if (command.Equals("add") ||
                command.Equals("subtract") ||
                command.Equals("multiply"))
            {
                args[0] = int.Parse(lineParams[1]);
                args[1] = int.Parse(lineParams[2]);
            }

            PerformAction(array, command, args);

            PrintArray(array);

            line = Console.ReadLine().Trim();
        }
    }

    static void PerformAction(long[] array, string action, int[] args)
    {
        int value = 0, pos = 0;
        if (args.Length > 0)
        {
            pos = args[0] - 1;
            value = args[1];
        }

        switch (action)
        {
            case "multiply":
                array[pos] *= value;
                break;
            case "add":
                array[pos] += value;
                break;
            case "subtract":
                array[pos] -= value;
                break;
            case "lshift":
                ArrayShiftLeft(array);
                break;
            case "rshift":
                ArrayShiftRight(array);
                break;
        }
    }

    private static void ArrayShiftRight(long[] array)
    {
        var lastElement = array[array.Length - 1];

        for (int i = array.Length - 1; i >= 1; i--)
        {
            array[i] = array[i - 1];
        }

        array[0] = lastElement;
    }

    private static void ArrayShiftLeft(long[] array)
    {
        var firstElement = array[0];

        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }

        array[array.Length - 1] = firstElement;
    }

    private static void PrintArray(long[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }
}

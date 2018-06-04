using System;
using System.Threading;

public class StartUp
{
    private static void Main()
    {
        var tokens = Console.ReadLine().Split(' ');
        var first = int.Parse(tokens[0]);
        var second = int.Parse(tokens[1]);
        var thread = new Thread(() => PrintNumbers(first, second));
        thread.Start();
        thread.Join();
        Console.WriteLine("Thread finished work");
    }

    private static void PrintNumbers(int first, int second)
    {
        first = Math.Min(first, second);
        second = Math.Max(first, second);
        while (first <= second)
        {
            Console.WriteLine(first++);
        }
    }
}
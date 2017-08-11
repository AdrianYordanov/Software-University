using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var stones = Console.ReadLine()
            .Split(
                new[]
                {
                    ' ',
                    ','
                },
                StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);
        var lake = new Lake(stones);
        Console.WriteLine(string.Join(", ", lake));
    }
}
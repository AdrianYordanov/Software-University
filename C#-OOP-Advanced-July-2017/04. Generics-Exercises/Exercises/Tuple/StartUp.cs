using System;

public class StartUp
{
    public static void Main()
    {
        var tokens = Console.ReadLine().Split(' ');
        var adressTouple = new CustomTuple<string, string>($"{tokens[0]} {tokens[1]}", tokens[2]);
        tokens = Console.ReadLine().Split(' ');
        var beerTuple = new CustomTuple<string, int>(tokens[0], int.Parse(tokens[1]));
        tokens = Console.ReadLine().Split(' ');
        var lastTuple = new CustomTuple<int, double>(int.Parse(tokens[0]), double.Parse(tokens[1]));
        Console.WriteLine(adressTouple);
        Console.WriteLine(beerTuple);
        Console.WriteLine(lastTuple);
    }
}
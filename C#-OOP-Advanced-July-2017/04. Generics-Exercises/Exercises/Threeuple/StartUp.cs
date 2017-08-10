using System;

public class StartUp
{
    public static void Main()
    {
        var tokens = Console.ReadLine().Split(' ');
        var adressThreeuple = new CustomThreeuple<string, string, string>($"{tokens[0]} {tokens[1]}", tokens[2], tokens[3]);
        tokens = Console.ReadLine().Split(' ');
        var isDrunk = tokens[2] == "drunk";
        var beerThreeuple = new CustomThreeuple<string, int, bool>(tokens[0], int.Parse(tokens[1]), isDrunk);
        tokens = Console.ReadLine().Split(' ');
        var bankThreeuple = new CustomThreeuple<string, double, string>(tokens[0], double.Parse(tokens[1]), tokens[2]);
        Console.WriteLine(adressThreeuple);
        Console.WriteLine(beerThreeuple);
        Console.WriteLine(bankThreeuple);
    }
}
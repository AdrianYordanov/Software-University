using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var data = new List<IName>();
        var input = Console.ReadLine();
        var dataNumber = int.Parse(input);
        for (var i = 0; i < dataNumber; ++i)
        {
            input = Console.ReadLine();
            var tokens = input.Split(' ');
            if (tokens.Length == 3)
            {
                data.Add(new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }
            else if (tokens.Length == 4)
            {
                data.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
            }
        }

        while ((input = Console.ReadLine()) != "End")
        {
            try
            {
                var target = data.First(x => x.Name == input);
                ((IBuyer)target).BuyFood();
            }
            catch (Exception)
            {
                // Nothing happens if invalid name.
            }
        }

        var counter = data.Sum(x => ((IBuyer)x).Food);
        Console.WriteLine(counter);
    }
}
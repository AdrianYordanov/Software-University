using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var engines = new List<Engine>();
        var cars = new List<Car>();
        for (var i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = tokens[0];
            var power = int.Parse(tokens[1]);
            switch (tokens.Length)
            {
                case 2:
                    engines.Add(new Engine(model, power));
                    break;
                case 3:
                    engines.Add(
                        int.TryParse(tokens[2], out var displacement) ?
                            new Engine(model, power, displacement) :
                            new Engine(model, power, tokens[2]));
                    break;
                case 4:
                    engines.Add(new Engine(model, power, int.Parse(tokens[2]), tokens[3]));
                    break;
            }
        }

        n = int.Parse(Console.ReadLine());
        for (var i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = tokens[0];
            var engine = engines.First(e => e.Model == tokens[1]);
            switch (tokens.Length)
            {
                case 2:
                    cars.Add(new Car(model, engine));
                    break;
                case 3:
                    cars.Add(
                        int.TryParse(tokens[2], out var weight) ?
                            new Car(model, engine, weight) :
                            new Car(model, engine, tokens[2]));
                    break;
                case 4:
                    cars.Add(new Car(model, engine, int.Parse(tokens[2]), tokens[3]));
                    break;
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}
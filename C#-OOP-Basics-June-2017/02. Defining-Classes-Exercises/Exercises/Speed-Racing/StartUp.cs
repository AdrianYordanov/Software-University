using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        var cars = new Dictionary<string, Car>();
        var n = int.Parse(Console.ReadLine());
        var input = string.Empty;

        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine();
            var tokens = input.Split(' ');
            var model = tokens[0];
            var amount = double.Parse(tokens[1]);
            var consumption = double.Parse(tokens[2]);
            cars.Add(model, new Car(model, amount, consumption));
        }

        while ((input=Console.ReadLine())!="End")
        {
            var tokens = input.Split(' ');
            var model = tokens[1];
            var distanceForTraveling = int.Parse(tokens[2]);
            var currentCar = cars[model];
            
            if(!currentCar.CanTravelDistance(distanceForTraveling))
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, cars.Values));
    }
}
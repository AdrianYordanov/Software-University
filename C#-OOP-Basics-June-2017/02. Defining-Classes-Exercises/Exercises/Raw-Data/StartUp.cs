using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var cars = new List<Car>();
        string input;
        for (var i = 0; i < n; i++)
        {
            input = Console.ReadLine();
            var tokens = input.Split(' ');
            var model = tokens[0];
            var speed = int.Parse(tokens[1]);
            var power = int.Parse(tokens[2]);
            var weight = int.Parse(tokens[3]);
            var type = tokens[4];
            var pressure1 = double.Parse(tokens[5]);
            var age1 = int.Parse(tokens[6]);
            var pressure2 = double.Parse(tokens[7]);
            var age2 = int.Parse(tokens[8]);
            var pressure3 = double.Parse(tokens[9]);
            var age3 = int.Parse(tokens[10]);
            var pressure4 = double.Parse(tokens[11]);
            var age4 = int.Parse(tokens[12]);
            cars.Add(
                new Car(
                    model,
                    speed,
                    power,
                    weight,
                    type,
                    pressure1,
                    age1,
                    pressure2,
                    age2,
                    pressure3,
                    age3,
                    pressure4,
                    age4));
        }

        input = Console.ReadLine();
        if (input == "fragile")
        {
            cars = cars.Where(
                    car => car.CarCargo.Type == "fragile"
                           && (car.Tires[0].Pressure < 1
                               || car.Tires[1].Pressure < 1
                               || car.Tires[2].Pressure < 1
                               || car.Tires[3].Pressure < 1))
                .ToList();
        }
        else if (input == "flamable")
        {
            cars = cars.Where(car => car.CarCargo.Type == "flamable" && car.CarEngine.Power > 250).ToList();
        }

        Console.WriteLine(string.Join(Environment.NewLine, cars));
    }
}
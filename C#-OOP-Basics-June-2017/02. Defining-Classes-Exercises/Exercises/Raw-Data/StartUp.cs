using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var cars = new List<Car>();
        var input = string.Empty;

        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine();
            var tokens = input.Split(' ');
            string model = tokens[0];
            int speed = int.Parse(tokens[1]);
            int power = int.Parse(tokens[2]);
            int weight = int.Parse(tokens[3]);
            string type = tokens[4];
            double pressure1 = double.Parse(tokens[5]);
            int age1 = int.Parse(tokens[6]);
            double pressure2 = double.Parse(tokens[7]);
            int age2 = int.Parse(tokens[8]);
            double pressure3 = double.Parse(tokens[9]);
            int age3 = int.Parse(tokens[10]);
            double pressure4 = double.Parse(tokens[11]);
            int age4 = int.Parse(tokens[12]);
            cars.Add(new Car(model, speed, power, weight, type, pressure1, age1, pressure2, age2, pressure3, age3, pressure4, age4));
        }

        input = Console.ReadLine();

        if (input == "fragile")
        {
            cars = cars
                .Where(car => car.CarCargo.Type == "fragile" &&
                     (car.Tires[0].Pressure < 1 ||
                        car.Tires[1].Pressure < 1 ||
                        car.Tires[2].Pressure < 1 ||
                        car.Tires[3].Pressure < 1))
                .ToList();
        }
        else if (input == "flamable")
        {
            cars = cars
                .Where(car => car.CarCargo.Type == "flamable" && car.CarEngine.Power > 250)
                .ToList();
        }

        Console.WriteLine(string.Join(Environment.NewLine, cars));
    }
}

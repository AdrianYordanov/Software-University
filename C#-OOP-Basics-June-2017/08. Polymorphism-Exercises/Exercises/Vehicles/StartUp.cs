using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var carTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var truckTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var n = int.Parse(Console.ReadLine());
        var vehicles = new List<Vehicle>()
        {
            new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2])),
            new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]))
        };

        for (int i = 0; i < n; i++)
        {
            var commandTokens = Console.ReadLine().Split(' ');
            var vehicleType = commandTokens[1];
            var command = commandTokens[0];
            var distanceOrLiters = commandTokens[2];
            var currentVehicle = vehicles.First(vehicle => vehicle.GetType().ToString() == vehicleType);

            if (command == "Drive")
            {
                try
                {
                    currentVehicle.Drive(double.Parse(distanceOrLiters));
                    Console.WriteLine($"{vehicleType} travelled {distanceOrLiters} km");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine($"{vehicleType} needs refueling");
                }
            }
            else if (command == "Refuel")
            {
                currentVehicle.Refuel(double.Parse(distanceOrLiters));
            }
        }

        vehicles.ForEach(vehicle => Console.WriteLine(vehicle));
    }
}
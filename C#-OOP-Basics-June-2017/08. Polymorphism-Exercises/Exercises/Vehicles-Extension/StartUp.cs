using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var carTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var truckTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var busTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var n = int.Parse(Console.ReadLine());

        var vehicles = new List<Vehicle>()
        {
            new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3])),
            new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]), double.Parse(truckTokens[3])),
            new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]))
        };

        for (int i = 0; i < n; i++)
        {
            var commandTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var vehicleType = commandTokens[1];
            var command = commandTokens[0];
            var distanceOrLiters = double.Parse(commandTokens[2]);
            var currentVehicle = vehicles.First(vehicle => vehicle.GetType().ToString() == vehicleType);

            try
            {
                switch (command)
                {
                    case "Drive":
                        currentVehicle.Drive(distanceOrLiters);
                        Console.WriteLine($"{vehicleType} travelled {distanceOrLiters} km");
                        break;
                    case "Refuel":
                        currentVehicle.Refuel(distanceOrLiters);
                        break;
                    case "DriveEmpty":
                        (currentVehicle as Bus).DriveEmpty(distanceOrLiters);
                        Console.WriteLine($"{vehicleType} travelled {distanceOrLiters} km");
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }

        vehicles.ForEach(vehicle => Console.WriteLine(vehicle));
    }
}
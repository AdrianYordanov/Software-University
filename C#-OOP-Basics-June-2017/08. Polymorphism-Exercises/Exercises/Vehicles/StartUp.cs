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
            var commandTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var vehicleType = commandTokens[1];
            var command = commandTokens[0];
            var distanceOrLiters = double.Parse(commandTokens[2]);
            var currentVehicle = vehicles.First(vehicle => vehicle.GetType().ToString() == vehicleType);

            try
            {
                if (command == "Drive")
                {

                    currentVehicle.Drive(distanceOrLiters);
                    Console.WriteLine($"{vehicleType} travelled {distanceOrLiters} km");
                }
                else if (command == "Refuel")
                {
                    currentVehicle.Refuel(distanceOrLiters);
                }
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }

        vehicles.ForEach(vehicle => Console.WriteLine(vehicle));
    }
}
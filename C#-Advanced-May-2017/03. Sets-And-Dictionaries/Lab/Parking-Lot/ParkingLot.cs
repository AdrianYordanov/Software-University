using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ParkingLot
{
    private static void Main()
    {
        var input = Console.ReadLine();
        var parking = new SortedSet<string>();
        while (input != "END")
        {
            var tokens = Regex.Split(input, "[, ]+", RegexOptions.IgnorePatternWhitespace);
            var operation = tokens[0];
            var carNumber = tokens[1];
            if (operation == "IN")
            {
                parking.Add(carNumber);
            }
            else if (operation == "OUT")
            {
                parking.Remove(carNumber);
            }

            input = Console.ReadLine();
        }

        if (parking.Count != 0)
        {
            foreach (var car in parking)
            {
                Console.WriteLine(car);
            }
        }
        else
        {
            Console.WriteLine("Parking Lot is Empty");
        }
    }
}
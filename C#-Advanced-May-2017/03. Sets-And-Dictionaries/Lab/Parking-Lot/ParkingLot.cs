using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ParkingLot
{
    static void Main()
    {
        var input = Console.ReadLine();
        var parking = new SortedSet<string>();

        while (input != "END")
        {
            var tokens = Regex.Split(input, "[, ]+", RegexOptions.IgnorePatternWhitespace);
            var operation = tokens[0];
            var carNumber = tokens[1];

            switch (operation)
            {
                case "IN": parking.Add(carNumber); break;
                case "OUT": parking.Remove(carNumber); break;
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
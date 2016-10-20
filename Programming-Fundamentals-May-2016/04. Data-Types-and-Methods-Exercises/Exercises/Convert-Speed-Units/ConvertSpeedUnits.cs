using System;

class ConvertSpeedUnits
{
    static void Main()
    {
        float distanceInMeters = float.Parse(Console.ReadLine());
        float distanceInKilometers = distanceInMeters / 1000;
        float distanceInMiles = distanceInMeters / 1609;

        uint hours = uint.Parse(Console.ReadLine());
        uint minutes = uint.Parse(Console.ReadLine());
        uint seconds = uint.Parse(Console.ReadLine());
        uint totalSeconds = seconds + (( minutes + (hours * 60)) * 60);
        float totalHours = (float)totalSeconds / 60 / 60;

        Console.WriteLine("{0}", distanceInMeters / totalSeconds);
        Console.WriteLine("{0}", distanceInKilometers / totalHours);
        Console.WriteLine("{0}", distanceInMiles / totalHours);
    }
}
using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var initialLights = Console.ReadLine()
            .Split(
                new[]
                {
                    ' '
                },
                StringSplitOptions.RemoveEmptyEntries);
        var trafficLights = initialLights.Select(light => new TrafficLight(light))
            .Cast<ITrafficLight>()
            .ToList();
        var n = int.Parse(Console.ReadLine());
        for (var i = 0; i < n; i++)
        {
            trafficLights.ForEach(l => l.Cycle());
            Console.WriteLine(string.Join(" ", trafficLights));
        }
    }
}
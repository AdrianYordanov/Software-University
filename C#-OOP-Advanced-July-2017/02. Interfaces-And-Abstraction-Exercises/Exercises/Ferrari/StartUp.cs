using System;

public class StartUp
{
    public static void Main()
    {
        // ReSharper disable once UnusedVariable
        var ferrariName = typeof(Ferrari).Name;
        // ReSharper disable once UnusedVariable
        var carInterfaceName = typeof(ICar).Name;

        var isCreated = typeof(ICar).IsInterface;
        if (!isCreated)
        {
            throw new Exception("No interface ICar was created");
        }

        var driver = Console.ReadLine();
        Console.WriteLine(new Ferrari(driver));
    }
}
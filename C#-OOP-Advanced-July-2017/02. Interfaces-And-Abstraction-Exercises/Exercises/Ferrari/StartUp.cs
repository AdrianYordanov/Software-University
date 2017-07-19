using System;

public class StartUp
{
    public static void Main()
    {
        var ferrariName = typeof(Ferrari).Name;
        var iCarInterfaceName = typeof(ICar).Name;

        var isCreated = typeof(ICar).IsInterface;
        if (!isCreated)
        {
            throw new Exception("No interface ICar was created");
        }

        var driver = Console.ReadLine();
        Console.WriteLine(new Ferrari(driver));
    }
}
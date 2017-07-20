using System;

public class StartUp
{
    public static void Main()
    {
        var scale = new Scale<int>(2, 3);
        Console.WriteLine(scale.GetHavier());
    }
}
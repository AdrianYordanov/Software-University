using System;

public class StartUp
{
    private static void Main()
    {
        var result = new Spy().CollectGettersAndSetters("Hacker");
        Console.Write(result);
    }
}
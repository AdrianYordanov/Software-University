using System;

public class StartUp
{
    private static void Main()
    {
        var result = new Spy().RevealPrivateMethods("Hacker");
        Console.Write(result);
    }
}
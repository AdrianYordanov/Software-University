using System;

public class StartUp
{
    private static void Main()
    {
        var result = new Spy().AnalyzeAcessModifiers("Hacker");
        Console.Write(result);
    }
}
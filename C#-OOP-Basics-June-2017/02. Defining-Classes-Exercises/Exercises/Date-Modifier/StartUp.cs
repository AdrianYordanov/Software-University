using System;

class StartUp
{
    static void Main()
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();
        var modifier = new DateModifier(firstDate, secondDate);
        Console.WriteLine(modifier.Result);
    }
}
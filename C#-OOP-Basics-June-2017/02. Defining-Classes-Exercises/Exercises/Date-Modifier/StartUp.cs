using System;

public class StartUp
{
    private static void Main()
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();
        try
        {
            var modifier = new DateModifier(firstDate, secondDate);
            Console.WriteLine(modifier.Result);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        var chickenType = typeof(Chicken);
        var fields = chickenType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        var methods = chickenType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        Debug.Assert(fields.Where(f => f.IsPrivate).Count() == 2);
        Debug.Assert(methods.Where(m => m.IsPrivate).Count() == 1);

        var name = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());

        try
        {
            Chicken chicken = new Chicken(name, age);
            Console.WriteLine(
                "Chicken {0} (age {1}) can produce {2} eggs per day.",
                chicken.Name,
                chicken.Age,
                chicken.GetProductPerDay());
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
using System;

public class StartUp
{
    public static void Main()
    {
        var smartPhone = new Smartphone();
        var numbers = Console.ReadLine().Split(' ');
        var sites = Console.ReadLine().Split(' ');

        foreach (var number in numbers)
        {
            smartPhone.AddPhone(number);
        }

        foreach (var site in sites)
        {
            smartPhone.AddSite(site);
        }

        PrintPhones(smartPhone);
        PrintSites(smartPhone);
    }

    private static void PrintPhones(ICallable phones)
    {
        Console.WriteLine(phones.Call());
    }

    private static void PrintSites(IBrowsable phones)
    {
        Console.WriteLine(phones.Browse());
    }
}
using System;
using System.Collections.Generic;

public class StartUp
{
    private static void Main()
    {
        var accounts = new List<BankAccount>
                       {
                           new BankAccount(1, 15),
                           new BankAccount(1, 20),
                           new BankAccount(1, 3),
                           new BankAccount(1, 5)
                       };
        var person = new Person("Pehso", 18, accounts);
        Console.WriteLine($"{person.Name} {person.Age} {person.GetBalance()}");
    }
}
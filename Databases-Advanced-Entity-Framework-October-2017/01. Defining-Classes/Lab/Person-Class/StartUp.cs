using System;
using System.Collections.Generic;

public class StartUp
{
    private static void Main()
    {
        var accounts = new List<BankAccount>
        {
            new BankAccount
            {
                ID = 1,
                Balance = 15
            },
            new BankAccount
            {
                ID = 1,
                Balance = 20
            },
            new BankAccount
            {
                ID = 1,
                Balance = 3
            },
            new BankAccount
            {
                ID = 1,
                Balance = 5
            }
        };
        var person = new Person("Pehso", 18, accounts);
        Console.WriteLine(person.GetBalance());
    }
}
using System;

class StartUp
{
    static void Main()
    {
        var account = new BankAccount();
        account.ID = 1;
        account.Balance = 15;
        Console.WriteLine($"Account {account.ID}, balance {account.Balance}");
    }
}
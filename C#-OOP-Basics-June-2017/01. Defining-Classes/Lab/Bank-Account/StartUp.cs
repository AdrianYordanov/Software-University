using System;

public class StartUp
{
    private static void Main()
    {
        var account = new BankAccount(1, 15);
        Console.WriteLine($"Account {account.Id}, balance {account.Balance}");
    }
}
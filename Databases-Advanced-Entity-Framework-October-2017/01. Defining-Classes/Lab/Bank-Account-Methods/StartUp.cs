using System;

public class StartUp
{
    private static void Main()
    {
        var account = new BankAccount();
        account.ID = 1;
        account.Deposit(15);
        account.Withdraw(5);
        Console.WriteLine(account);
    }
}
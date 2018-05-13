using System.Collections.Generic;
using System.Linq;

public class Person
{
    private readonly List<BankAccount> accounts;

    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.Name = name;
        this.Age = age;
        this.accounts = accounts;
    }

    public int Age { get; }

    public string Name { get; }

    public double GetBalance()
    {
        return this.accounts.Sum(account => account.Balance);
    }
}
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private readonly List<BankAccount> accounts;
    private string name;
    private int age;

    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.Name = name;
        this.Age = age;
        this.accounts = accounts;
    }

    public Person(string name, int age)
        : this(name, age, new List<BankAccount>())
    {
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }

    public double GetBalance()
    {
        return this.accounts.Sum(account => account.Balance);
    }
}
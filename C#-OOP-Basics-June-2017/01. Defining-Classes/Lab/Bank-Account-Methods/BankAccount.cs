public class BankAccount
{
    public BankAccount(int id, double ballance = 0)
    {
        this.Id = id;
        this.Balance = ballance;
    }

    public int Id { get; }

    public double Balance { get; private set; }

    public void Deposit(double amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(double amount)
    {
        this.Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {this.Id}, balance {this.Balance}";
    }
}
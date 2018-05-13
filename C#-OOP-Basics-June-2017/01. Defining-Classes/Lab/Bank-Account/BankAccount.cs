public class BankAccount
{
    public BankAccount(int id, double ballanance)
    {
        this.Id = id;
        this.Balance = ballanance;
    }

    public int Id { get; }

    public double Balance { get; }
}
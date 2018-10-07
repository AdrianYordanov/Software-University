namespace Black_Wars_Return_Of_The_Dependencies.Contracts
{
    public interface IRepository
    {
        string Statistics
        {
            get;
        }

        void AddUnit(IUnit unit);

        void RemoveUnit(string unitType);
    }
}
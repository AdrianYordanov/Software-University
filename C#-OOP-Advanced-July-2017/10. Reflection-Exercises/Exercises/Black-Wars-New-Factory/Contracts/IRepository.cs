namespace Black_Wars_New_Factory.Contracts
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
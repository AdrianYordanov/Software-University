namespace Black_Wars_The_Command_Strike_Back.Contracts
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
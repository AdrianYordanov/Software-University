namespace Black_Wars_The_Command_Strike_Back.Contracts
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}
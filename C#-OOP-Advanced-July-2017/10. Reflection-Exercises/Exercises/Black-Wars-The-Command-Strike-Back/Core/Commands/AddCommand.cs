namespace Black_Wars_The_Command_Strike_Back.Core.Commands
{
    using Contracts;

    public class AddCommand : Command
    {
        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var unitType = this.Data[1];
            var unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            var output = unitType + " added!";
            return output;
        }
    }
}
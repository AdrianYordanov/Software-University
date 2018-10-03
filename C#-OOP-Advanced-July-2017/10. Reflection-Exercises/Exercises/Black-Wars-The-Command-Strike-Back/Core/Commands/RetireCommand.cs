namespace Black_Wars_The_Command_Strike_Back.Core.Commands
{
    using System;
    using Contracts;

    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var unit = this.Data[1];
            try
            {
                this.Repository.RemoveUnit(unit);
                return $"{unit} retired!";
            }
            catch (Exception)
            {
                return "No such units in repository.";
            }
        }
    }
}
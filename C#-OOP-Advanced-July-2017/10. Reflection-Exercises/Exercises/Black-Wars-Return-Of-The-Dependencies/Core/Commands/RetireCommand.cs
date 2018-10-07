namespace Black_Wars_Return_Of_The_Dependencies.Core.Commands
{
    using System;
    using Attributes;
    using Contracts;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            var unit = this.Data[1];
            try
            {
                this.repository.RemoveUnit(unit);
                return $"{unit} retired!";
            }
            catch (Exception)
            {
                return "No such units in repository.";
            }
        }
    }
}
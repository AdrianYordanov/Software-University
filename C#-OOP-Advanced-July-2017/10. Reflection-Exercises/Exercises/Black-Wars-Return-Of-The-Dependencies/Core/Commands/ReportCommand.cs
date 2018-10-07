namespace Black_Wars_Return_Of_The_Dependencies.Core.Commands
{
    using Attributes;
    using Contracts;

    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            var output = this.repository.Statistics;
            return output;
        }
    }
}
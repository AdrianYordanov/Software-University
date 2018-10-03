namespace Black_Wars_The_Command_Strike_Back.Core.Commands
{
    using Contracts;

    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var output = this.Repository.Statistics;
            return output;
        }
    }
}
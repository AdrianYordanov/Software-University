namespace Black_Wars_Return_Of_The_Dependencies.Core.Commands
{
    using Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.data = data;
        }

        protected string[] Data
        {
            get => this.data;
            private set => this.data = value;
        }

        public abstract string Execute();
    }
}
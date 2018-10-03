namespace Black_Wars_The_Command_Strike_Back.Core
{
    using System;
    using Contracts;

    public class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    var data = input.Split();
                    var commandName = data[0];
                    var result = this.InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            var commandClassName = char.ToUpper(commandName[0]) + commandName.Substring(1, commandName.Length - 1);
            var commandType = Type.GetType($"Black_Wars_The_Command_Strike_Back.Core.Commands.{commandClassName}Command");
            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var commandInstance = (IExecutable) commandType
               .GetConstructor(new[] {typeof(string[]), typeof(IRepository), typeof(IUnitFactory)})
               .Invoke(new object[] {data, this.repository, this.unitFactory});
            var output = commandInstance.Execute();
            return output;
        }
    }
}
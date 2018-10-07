namespace Black_Wars_Return_Of_The_Dependencies.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
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
            var commandType =
                Type.GetType($"Black_Wars_Return_Of_The_Dependencies.Core.Commands.{commandClassName}Command");
            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }
            
            var commandFields = commandType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
               .Where(field => field.IsDefined(typeof(InjectAttribute), false))
               .ToArray();
            var necessaryTypes = commandFields.Select(field => field.FieldType)
               .ToList();
            necessaryTypes.Insert(0, data.GetType());
            var typeValues = commandFields.Select(field => typeof(Engine)
                   .GetField(field.Name, BindingFlags.Instance | BindingFlags.NonPublic)
                   .GetValue(this))
               .ToList();
            typeValues.Insert(0, data);
            var commandInstance = (IExecutable) commandType.GetConstructor(necessaryTypes.ToArray())
               .Invoke(typeValues.ToArray());
            var output = commandInstance.Execute();
            return output;
        }
    }
}
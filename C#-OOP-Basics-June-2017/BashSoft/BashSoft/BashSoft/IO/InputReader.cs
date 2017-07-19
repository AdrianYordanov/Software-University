namespace BashSoft.IO
{
    using System;
    using StaticData;

    public class InputReader
    {
        private const string EndCommand = "quit";
        private readonly CommandInterpreter interpreter;

        public InputReader(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionsData.CurrentPath}> ");
                // ReSharper disable once PossibleNullReferenceException
                var input = Console.ReadLine().Trim();
                if (input == EndCommand)
                {
                    break;
                }

                this.interpreter.InterpredCommand(input);
            }
        }
    }
}
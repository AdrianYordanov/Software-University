namespace BashSoft.IO
{
    using System;
    using StaticData;

    public static class InputReader
    {
        private const string EndCommand = "quit";

        public static void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
            // ReSharper disable once PossibleNullReferenceException
            var input = Console.ReadLine().Trim();

            while (input != EndCommand)
            {
                CommandInterpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
                // ReSharper disable once PossibleNullReferenceException
                input = Console.ReadLine().Trim();
            }
        }
    }
}
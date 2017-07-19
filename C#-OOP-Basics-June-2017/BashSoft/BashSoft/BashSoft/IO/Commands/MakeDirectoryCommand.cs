﻿namespace BashSoft.IO.Commands
{
    using BashSoft.Exceptions;

    public class MakeDirectoryCommand : Command
    {
        public MakeDirectoryCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        { }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                var folderName = this.Data[1];
                this.InputOutputManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
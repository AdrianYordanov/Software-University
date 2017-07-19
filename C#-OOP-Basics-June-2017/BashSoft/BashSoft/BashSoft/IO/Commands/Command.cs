namespace BashSoft.IO.Commands
{
    using System;
    using Exceptions;
    using Judge;
    using Repository;

    public abstract class Command
    {
        private string[] data;

        private string input;

        protected Command(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.Input = input;
            this.Data = data;
            this.Judge = judge;
            this.Repository = repository;
            this.InputOutputManager = inputOutputManager;
        }

        public string[] Data
        {
            get => this.data;

            protected set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        public string Input
        {
            get => this.input;

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        protected Tester Judge { get; }

        protected StudentsRepository Repository { get; }

        protected IOManager InputOutputManager { get; }

        public abstract void Execute();
    }
}
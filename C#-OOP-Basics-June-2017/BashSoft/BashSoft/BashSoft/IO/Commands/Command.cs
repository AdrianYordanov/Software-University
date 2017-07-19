﻿namespace BashSoft.IO.Commands
{
    using System;
    using BashSoft.Exceptions;

    public abstract class Command
    {
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;

        private string input;
        private string[] data;

        protected Command(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.Input = input;
            this.Data = data;
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        protected Tester Judge
        {
            get
            {
                return this.judge;
            }
        }

        protected StudentsRepository Repository
        {
            get
            {
                return this.repository;
            }
        }

        protected IOManager InputOutputManager
        {
            get
            {
                return this.inputOutputManager;
            }
        }

        public string[] Data
        {
            get
            {
                return this.data;
            }
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
            get
            {
                return this.input;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        public abstract void Execute();
    }
}
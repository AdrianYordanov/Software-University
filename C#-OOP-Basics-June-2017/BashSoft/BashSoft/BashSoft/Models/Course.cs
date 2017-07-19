namespace BashSoft.Models
{
    using System.Collections.Generic;
    using Exceptions;

    public class Course
    {
        public const int MaxScoreOnExamTasks = 100;
        public const int NumberOfTasksOnExam = 5;
        private readonly Dictionary<string, Student> studentsByName;
        private string name;

        public Course(string name)
        {
            this.name = name;
            this.studentsByName = new Dictionary<string, Student>();
        }

        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, Student> StudentsByName => this.studentsByName;

        public void EntrollStudent(Student student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
            }

            this.studentsByName.Add(student.UserName, student);
        }
    }
}
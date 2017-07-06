using System;
using System.Text;
using System.Linq;

class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get
        {
            return this.facultyNumber;
        }
        private set
        {
            if (value.Length < 5 || value.Length > 10 || !value.All(character => char.IsLetterOrDigit(character)))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append(base.ToString());
        sb.Append($"Faculty number: {this.FacultyNumber}");
        return sb.ToString();
    }
}
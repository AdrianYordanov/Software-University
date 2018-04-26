public class Student
{
    public Student(string facultyNumber, string studentName)
    {
        this.FacultyNumber = facultyNumber;
        this.StudentName = studentName;
    }

    public string FacultyNumber { get; set; }

    public string StudentName { get; set; }
}
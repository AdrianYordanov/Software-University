using System;
using System.Collections.Generic;
using System.Linq;

class StudentsJoinedToSpecialties
{
    static void Main()
    {
        var listOfSpecialty = new List<StudentSpecialty>();
        var listOfStudents = new List<Student>();
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "Students:")
        {
            var current = new StudentSpecialty();
            var splitInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            current.SpecialtyName = splitInput[0] + " " + splitInput[1];
            current.FacultyNumbet = splitInput[2];
            listOfSpecialty.Add(current);
        }

        var secondINput = string.Empty;

        while ((secondINput = Console.ReadLine()) != "END")
        {
            var current = new Student();
            var splitInput2 = secondINput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            current.FacultyNumbet = splitInput2[0];
            current.StudentName = splitInput2[1] + " " + splitInput2[2];
            listOfStudents.Add(current);
        }

        var result = listOfStudents
            .Join(listOfSpecialty, student => student.FacultyNumbet, specialty => specialty.FacultyNumbet, (student, specialty)
            => new { student.StudentName, student.FacultyNumbet, specialty.SpecialtyName }).OrderBy(student => student.StudentName);

        foreach (var item in result)
        {
            Console.WriteLine($"{item.StudentName} {item.FacultyNumbet} {item.SpecialtyName}");
        }
    }
}

public class StudentSpecialty
{
    public string SpecialtyName { get; set; }
    public string FacultyNumbet { get; set; }
}

public class Student
{
    public string StudentName { get; set; }
    public string FacultyNumbet { get; set; }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class StudentsJoinedToSpecialties
{
    private static void Main()
    {
        var listOfSpecialty = new List<StudentSpecialty>();
        var listOfStudents = new List<Student>();
        string input;
        while ((input = Console.ReadLine()) != "Students:")
        {
            var splitInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            listOfSpecialty.Add(new StudentSpecialty(splitInput[2], splitInput[0] + " " + splitInput[1]));
        }

        while ((input = Console.ReadLine()) != "END")
        {
            var splitInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            listOfStudents.Add(new Student(splitInput[0], splitInput[1] + " " + splitInput[2]));
        }

        var result = listOfStudents.Join(
                listOfSpecialty,
                student => student.FacultyNumber,
                specialty => specialty.FacultyNumber,
                (student, specialty) => new
                                        {
                                            student.StudentName,
                                            FacultyNumbet = student.FacultyNumber,
                                            specialty.SpecialtyName
                                        })
            .OrderBy(student => student.StudentName);
        foreach (var item in result)
        {
            Console.WriteLine($"{item.StudentName} {item.FacultyNumbet} {item.SpecialtyName}");
        }
    }
}
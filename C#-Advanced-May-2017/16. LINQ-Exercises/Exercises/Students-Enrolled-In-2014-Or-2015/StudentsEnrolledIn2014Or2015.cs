using System;
using System.Collections.Generic;
using System.Linq;

class StudentsEnrolledIn2014Or2015
{
    static void Main()
    {
        var input = string.Empty;
        var students = new List<string[]>();

        while ((input = Console.ReadLine()) != "END")
        {
            students.Add(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        var result = students
            .Where(s => s[0].EndsWith("14") || s[0].EndsWith("15"));

        foreach (var student in result)
        {
            Console.WriteLine(string.Join(" ", student.Skip(1)));
        }
    }
}
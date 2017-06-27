using System;
using System.Collections.Generic;
using System.Linq;

class FilterStudentsByPhone
{
    static void Main()
    {
        var input = Console.ReadLine();
        var students = new List<string[]>();

        while ((input = Console.ReadLine()) != "END")
        {
            students.Add(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        var result = students
            .Where(s => s[2].StartsWith("02") || s[2].StartsWith("+3592"));

        foreach (var student in result)
        {
            Console.WriteLine($"{student[0]} {student[1]}");
        }
    }
}
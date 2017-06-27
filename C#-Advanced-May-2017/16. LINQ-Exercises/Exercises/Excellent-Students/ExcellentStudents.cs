using System;
using System.Collections.Generic;
using System.Linq;

class ExcellentStudents
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
            .Where(s => s
            .Skip(2)
            .Any(n => n == "6"));

        foreach (var student in result)
        {
            Console.WriteLine($"{student[0]} {student[1]}");
        }
    }
}
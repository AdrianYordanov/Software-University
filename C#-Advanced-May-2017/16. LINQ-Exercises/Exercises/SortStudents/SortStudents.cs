using System;
using System.Collections.Generic;
using System.Linq;

class SortStudents
{
    static void Main()
    {
        var input = string.Empty;
        var students = new List<string[]>();

        while ((input = Console.ReadLine()) != "END")
        {
            students.Add(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        var result = students.
            OrderBy(s => s[1]).ThenByDescending(s => s[0]);

        foreach (var student in result)
        {
            Console.WriteLine($"{student[0]} {student[1]}");
        }
    }
}
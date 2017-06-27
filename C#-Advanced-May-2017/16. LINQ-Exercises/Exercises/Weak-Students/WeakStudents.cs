using System;
using System.Collections.Generic;
using System.Linq;

class WeakStudents
{
    static void Main()
    {
        var input = string.Empty;
        List<string[]> students = new List<string[]>();

        while ((input = Console.ReadLine()) != "END")
        {
            students.Add(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        var result = students
            .Where(s => s
            .Skip(2)
            .Count(m => int.Parse(m) <= 3) >= 2);

        foreach (var student in result)
        {
            Console.WriteLine($"{student[0]} {student[1]}");
        }
    }
}
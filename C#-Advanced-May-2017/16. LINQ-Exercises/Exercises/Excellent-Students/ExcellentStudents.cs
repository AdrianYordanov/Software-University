using System;
using System.Collections.Generic;
using System.Linq;

public class ExcellentStudents
{
    private static void Main()
    {
        var students = new List<string[]>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            students.Add(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        var result = students.Where(s => s.Skip(2).Any(n => n == "6"));
        foreach (var student in result)
        {
            Console.WriteLine($"{student[0]} {student[1]}");
        }
    }
}
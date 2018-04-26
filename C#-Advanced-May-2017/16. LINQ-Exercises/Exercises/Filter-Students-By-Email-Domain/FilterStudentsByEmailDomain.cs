using System;
using System.Collections.Generic;
using System.Linq;

public class FilterStudentsByEmailDomain
{
    private static void Main()
    {
        string input;
        var students = new List<string[]>();
        while ((input = Console.ReadLine()) != "END")
        {
            students.Add(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        var result = students.Where(s => s[2].Contains("@gmail.com"));
        foreach (var student in result)
        {
            Console.WriteLine($"{student[0]} {student[1]}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class SortStudents
{
    private static void Main()
    {
        string input;
        var students = new List<string[]>();
        while ((input = Console.ReadLine()) != "END")
        {
            students.Add(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        var result = students.OrderBy(s => s[1]).ThenByDescending(s => s[0]);
        foreach (var student in result)
        {
            Console.WriteLine($"{student[0]} {student[1]}");
        }
    }
}
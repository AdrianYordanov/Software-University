using System;
using System.Collections.Generic;
using System.Linq;

public class WeakStudents
{
    private static void Main()
    {
        var students = new List<string[]>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            students.Add(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        var result = students.Where(s => s.Skip(2).Count(m => int.Parse(m) <= 3) >= 2);
        foreach (var student in result)
        {
            Console.WriteLine($"{student[0]} {student[1]}");
        }
    }
}
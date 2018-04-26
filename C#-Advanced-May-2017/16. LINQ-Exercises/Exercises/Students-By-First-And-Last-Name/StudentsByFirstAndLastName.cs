using System;
using System.Collections.Generic;
using System.Linq;

public class StudentsByFirstAndLastName
{
    private static void Main()
    {
        string input;
        var studentNames = new List<string[]>();
        while ((input = Console.ReadLine()) != "END")
        {
            studentNames.Add(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        var result = studentNames.Where(s => string.Compare(s[0], s[1], StringComparison.Ordinal) < 0);
        foreach (var student in result)
        {
            Console.WriteLine($"{student[0]} {student[1]}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

class StudentsByFirstAndLastName
{
    static void Main()
    {
        var input = string.Empty;
        var studentNames = new List<string[]>();

        while ((input = Console.ReadLine()) != "END")
        {
            studentNames.Add(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        var result = studentNames
            .Where(s => s[0].CompareTo(s[1]) < 0);

        foreach (var student in result)
        {
            Console.WriteLine($"{student[0]} {student[1]}");
        }
    }
}
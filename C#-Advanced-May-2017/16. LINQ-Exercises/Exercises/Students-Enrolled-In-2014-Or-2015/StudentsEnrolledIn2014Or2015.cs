using System;
using System.Collections.Generic;
using System.Linq;

public class StudentsEnrolledIn2014Or2015
{
    private static void Main()
    {
        string input;
        var students = new List<string[]>();
        while ((input = Console.ReadLine()) != "END")
        {
            students.Add(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        var result = students.Where(s => s[0].EndsWith("14") || s[0].EndsWith("15"));
        foreach (var student in result)
        {
            Console.WriteLine(string.Join(" ", student.Skip(1)));
        }
    }
}
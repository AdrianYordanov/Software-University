using System;
using System.Collections.Generic;
using System.Linq;

class StudentsByAge
{
    static void Main()
    {
        string input = string.Empty;
        var studentsAndAges = new List<string[]>();

        while ((input = Console.ReadLine()) != "END")
        {
            studentsAndAges.Add(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        var result = studentsAndAges
             .Where(s => int.Parse(s[2]) >= 18 && int.Parse(s[2]) <= 24);

        foreach (var student in result)
        {
            Console.WriteLine($"{student[0]} {student[1]} {student[2]}");
        }
    }
}
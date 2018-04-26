using System;
using System.Collections.Generic;
using System.Linq;

public class StudentsByGroup
{
    private static void Main()
    {
        var listOfStudents = new List<string[]>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            listOfStudents.Add(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        var output = listOfStudents.Where(s => s[2] == "2").OrderBy(s => s[0]).Select(s => s[0] + " " + s[1]);
        Console.WriteLine(string.Join(Environment.NewLine, output));
    }
}
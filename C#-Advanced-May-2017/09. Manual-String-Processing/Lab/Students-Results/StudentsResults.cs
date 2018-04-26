using System;
using System.Collections.Generic;

public class StudentsResults
{
    private static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var strings = new List<string>();
        for (var i = 0; i < n; i++)
        {
            strings.Add(Console.ReadLine().Trim());
        }

        Console.WriteLine("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average");
        foreach (var item in strings)
        {
            var tokens = item.Split(new[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];
            var firstGrade = double.Parse(tokens[1]);
            var secondGrade = double.Parse(tokens[2]);
            var thirdGrade = double.Parse(tokens[3]);
            var average = (firstGrade + secondGrade + thirdGrade) / 3;
            Console.WriteLine(
                "{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|",
                name,
                firstGrade,
                secondGrade,
                thirdGrade,
                average);
        }
    }
}
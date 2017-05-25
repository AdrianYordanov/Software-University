﻿using System;
using System.Collections.Generic;
using System.Linq;

class AcademyGraduation
{
    static void Main()
    {
        var studentsCount = int.Parse(Console.ReadLine());
        var students = new SortedDictionary<string, double[]>();

        for (int i = 0; i < studentsCount; i++)
        {
            var name = Console.ReadLine();
            var grades = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            students.Add(name, grades);
        }

        foreach (var name in students.Keys)
        {
            Console.WriteLine($"{name} is graduated with {students[name].Average()}");
        }
    }
}
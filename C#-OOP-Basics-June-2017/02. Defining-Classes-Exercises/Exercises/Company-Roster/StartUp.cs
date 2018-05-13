using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var employees = new List<Employee>();
        for (var i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(' ');
            var name = tokens[0];
            var salary = decimal.Parse(tokens[1]);
            var position = tokens[2];
            var department = tokens[3];
            switch (tokens.Length)
            {
                case 4:
                    employees.Add(new Employee(name, salary, position, department));
                    break;
                case 5:
                    employees.Add(
                        int.TryParse(tokens[4], out var tempForAge) ?
                            new Employee(name, salary, position, department, tempForAge) :
                            new Employee(name, salary, position, department, tokens[4]));
                    break;
                case 6:
                    employees.Add(new Employee(name, salary, position, department, tokens[4], int.Parse(tokens[5])));
                    break;
            }
        }

        var bestDepartment = employees.GroupBy(employee => employee.Department, employee => employee.Salary)
            .OrderByDescending(departmentGroup => departmentGroup.Sum() / departmentGroup.Count())
            .First()
            .Key;
        var fromDepartment = employees.Where(employee => employee.Department == bestDepartment)
            .OrderByDescending(employee => employee.Salary);
        Console.WriteLine($"Highest Average Salary: {bestDepartment}");
        Console.WriteLine(string.Join(Environment.NewLine, fromDepartment));
    }
}
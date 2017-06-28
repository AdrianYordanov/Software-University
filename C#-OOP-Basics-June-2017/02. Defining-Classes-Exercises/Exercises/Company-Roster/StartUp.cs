using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(' ');
            var name = tokens[0];
            var salary = decimal.Parse(tokens[1]);
            var position = tokens[2];
            var department = tokens[3];

            if (tokens.Length == 4)
            {
                employees.Add(new Employee(name, salary, position, department));
            }
            else if (tokens.Length == 5)
            {
                var tempForAge = 0;

                if (int.TryParse(tokens[4], out tempForAge))
                {
                    employees.Add(new Employee(name, salary, position, department, tempForAge));
                }
                else
                {
                    employees.Add(new Employee(name, salary, position, department, tokens[4]));
                }
            }
            else if (tokens.Length == 6)
            {
                employees.Add(new Employee(name, salary, position, department, tokens[4], int.Parse(tokens[5])));
            }
        }

        var bestDepartment = employees
            .GroupBy(employee => employee.Department, employee => employee.Salary)
            .OrderByDescending(departmentGroup => departmentGroup.Sum() / departmentGroup.Count())
            .First()
            .Key;
        var fromDepartment = employees
            .Where(employee => employee.Department == bestDepartment)
            .OrderByDescending(employee => employee.Salary);
        Console.WriteLine($"Highest Average Salary: {bestDepartment}");
        Console.WriteLine(string.Join(Environment.NewLine, fromDepartment));
    }
}
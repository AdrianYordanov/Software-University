﻿namespace P02_DatabaseFirst.Exercises
{
    using System;
    using System.Linq;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class EmployeesFromResearchAndDevelopment
    {
        public void Run()
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees.Include(e => e.Departments)
                    .Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .Select(
                        e => new
                        {
                            e.FirstName,
                            e.LastName,
                            Department = e.Department.Name,
                            e.Salary
                        });
                foreach (var employee in employees)
                {
                    Console.WriteLine(
                        $"{employee.FirstName} {employee.LastName} from {employee.Department} - ${employee.Salary:F2}");
                }
            }
        }
    }
}
using System;
using System.Linq;
using Database_First.Data;

public class IncreaseSalaries
{
    public void Run()
    {
        using (var db = new SoftUniContext())
        {
            db.Employees.Where(
                    e => new[]
                    {
                        "Engineering",
                        "Tool Design",
                        "Marketing",
                        "Information Services"
                    }.Contains(e.Department.Name))
                .ToList()
                .ForEach(e => e.Salary *= 1.12m);
            db.SaveChanges();
            db.Employees.Where(
                    e => new[]
                    {
                        "Engineering",
                        "Tool Design",
                        "Marketing",
                        "Information Services"
                    }.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList()
                .ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})"));
        }
    }
}
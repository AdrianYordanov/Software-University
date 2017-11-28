using System;
using System.Linq;
using P02_DatabaseFirst.Data;

public class EmployeesWithSalaryOverFiftyThousand
{
    public void Run()
    {
        using (var db = new SoftUniContext())
        {
            var employees = db.Employees.Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => e.FirstName)
                .ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
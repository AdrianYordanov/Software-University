using System;
using System.Linq;
using P02_DatabaseFirst.Data;

public class DepartmentsWithMoreThanFiveEmployees
{
    public void Run()
    {
        using (var db = new SoftUniContext())
        {
            var departments = db.Departments.Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(
                    d => new
                    {
                        d.Name,
                        ManagerFirstName = d.Manager.FirstName,
                        ManagerLastName = d.Manager.LastName,
                        d.Employees
                    });
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");
                foreach (var employee in department.Employees.OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName))
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }

                Console.WriteLine(new string('-', 10));
            }
        }
    }
}
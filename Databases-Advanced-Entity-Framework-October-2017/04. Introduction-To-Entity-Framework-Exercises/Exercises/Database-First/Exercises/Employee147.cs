namespace Database_First.Exercises
{
    using System;
    using System.Linq;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class Employee147
    {
        public void Run()
        {
            using (var db = new SoftUniContext())
            {
                var employee = db.Employees.Include(e => e.EmployeesProjects)
                    .ThenInclude(e => e.Project)
                    .SingleOrDefault(e => e.EmployeeId == 147);
                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                foreach (var project in employee.EmployeesProjects.OrderBy(p => p.Project.Name))
                {
                    Console.WriteLine(project.Project.Name);
                }
            }
        }
    }
}
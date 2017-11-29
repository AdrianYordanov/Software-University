namespace Database_First.Exercises
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;

    public class EmployeesAndProjects
    {
        public void Run()
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees.Where(
                        e => e.EmployeesProjects.Any(
                            p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                    .Take(30)
                    .Select(
                        e => new
                        {
                            e.FirstName,
                            e.LastName,
                            ManagerFirstName = e.Manager.FirstName,
                            ManagerLastName = e.Manager.LastName,
                            Projects = e.EmployeesProjects.Select(ep => ep.Project)
                        })
                    .ToList();
                foreach (var employee in employees)
                {
                    Console.WriteLine(
                        $"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                    foreach (var project in employee.Projects)
                    {
                        var endDate = project.EndDate == null ?
                            "not finished" :
                            $"{project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}";
                        Console.WriteLine(
                            $"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");
                    }
                }
            }
        }
    }
}
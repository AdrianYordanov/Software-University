namespace P02_DatabaseFirst.Exercises
{
    using System;
    using System.Linq;
    using Data;

    public class FindEmployeesByFirstNameStartingWith
    {
        public void Run()
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees.Where(e => e.FirstName.StartsWith("Sa"))
                    .Select(
                        e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle,
                            e.Salary
                        })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName);
                foreach (var employee in employees)
                {
                    Console.WriteLine(
                        $"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
                }
            }
        }
    }
}
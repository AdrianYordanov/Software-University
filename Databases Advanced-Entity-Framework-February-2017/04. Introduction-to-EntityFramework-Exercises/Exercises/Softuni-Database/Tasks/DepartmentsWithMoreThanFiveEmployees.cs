namespace Softuni_Database.Tasks
{
    using System;
    using System.Linq;

    class DepartmentsWithMoreThanFiveEmployees
    {
        public static void Execute()
        {
            var context = new SoftuniContext();
            var departments = context.Departments;
            var filteredDepartments = departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ToList();

            foreach (var department in filteredDepartments)
            {
                Console.WriteLine($"{department.Name} {department.Manager.FirstName}");

                foreach (var employee in department.Employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
                }
            }
        }
    }
}

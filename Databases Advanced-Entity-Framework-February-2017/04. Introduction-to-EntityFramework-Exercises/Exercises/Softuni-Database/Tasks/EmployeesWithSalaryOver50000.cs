namespace Softuni_Database.Tasks
{
    using System;
    using System.Linq;

    class EmployeesWithSalaryOver50000
    {
        public static void Execute()
        {
            var context = new SoftuniContext();
            var employees = context.Employees.ToList();
            var filteredEmployees = employees.Where(e => e.Salary > 50000).ToList();
            filteredEmployees.ForEach(e => Console.WriteLine(e.FirstName));
        }
    }
}

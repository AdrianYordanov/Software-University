namespace Softuni_Database.Tasks
{
    using System;
    using System.Linq;
    class EmployeesFromSeattle
    {
        public static void Execute()
        {
            var context = new SoftuniContext();
            var employees = context.Employees.ToList();
            var filteredEmployees = employees
                .Where(e => e.DepartmentID == 6)
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();
            filteredEmployees
                .ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary.ToString("f2")}"));
        }
    }
}

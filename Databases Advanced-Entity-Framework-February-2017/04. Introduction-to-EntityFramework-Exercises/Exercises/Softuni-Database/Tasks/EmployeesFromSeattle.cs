using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni_Database.Tasks
{
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

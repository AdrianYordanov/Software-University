namespace Softuni_Database.Tasks
{
    using System;
    using System.Linq;

    class EmployeesFullInformation
    {
        public static void Execute()
        {
            var context = new SoftuniContext();
            var employees = context.Employees.ToList();

            employees.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary}"));
        }
    }
}

namespace Softuni_Database.Tasks
{
    using System;
    using System.Linq;

    class EmployeeWithId147
    {
        public static void Execute()
        {
            var context = new SoftuniContext();
            var employee = context.Employees.Where(e => e.EmployeeID == 147).ToArray()[0];
            var oredredProjects = employee.Projects
                .OrderBy(p => p.Name)
                .Select(p => p.Name)
                .ToList();

            Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            oredredProjects.ForEach(p => Console.WriteLine(p));
        }
    }
}

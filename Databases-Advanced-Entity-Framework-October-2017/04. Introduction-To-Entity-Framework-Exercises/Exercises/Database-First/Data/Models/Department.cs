// Rename namespace to "P02_DatabaseFirst.Data.Models" in judge
namespace Database_First.Data.Models
{
    using System.Collections.Generic;

    public class Department
    {
        public Department()
        {
            this.Employees = new HashSet<Employee>();
        }

        public int DepartmentId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int ManagerId
        {
            get;
            set;
        }

        public Employee Manager
        {
            get;
            set;
        }

        public ICollection<Employee> Employees
        {
            get;
            set;
        }
    }
}
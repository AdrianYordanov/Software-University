// Rename namespace to "P02_DatabaseFirst.Data.Models" in judge
namespace Database_First.Data.Models
{
    public class EmployeeProject
    {
        public int EmployeeId
        {
            get;
            set;
        }

        public int ProjectId
        {
            get;
            set;
        }

        public Employee Employee
        {
            get;
            set;
        }

        public Project Project
        {
            get;
            set;
        }
    }
}
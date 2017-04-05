namespace Softuni_Database
{
    using Softuni_Database.Tasks;

    class Startup
    {
        static void Main()
        {
            // Use dot(.) instead comma(,)
            System.Globalization.CultureInfo customCulture = 
                (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            
            EmployeesFullInformation.Execute();
        }
    }
}

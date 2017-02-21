using System.Data.SqlClient;
using System.IO;
class InitialSetup
{
    static void Main()
    {
        string createDatabaseQuery = File.ReadAllText("../../queries/create-database.sql");
        string createTablesQuery = File.ReadAllText("../../queries/create-tables.sql");

        SqlConnection connection = new SqlConnection("Server=ASUS-ADRIAN\\SQLEXPRESS;Integrated Security=true");
        connection.Open();

        using (connection)
        {
            SqlCommand createDatabaseCommand = new SqlCommand(createDatabaseQuery, connection);
            SqlCommand createTablesCommand = new SqlCommand(createTablesQuery, connection);

            using (createDatabaseCommand)
            {
                createDatabaseCommand.ExecuteNonQuery();
            }

            using (createTablesCommand)
            {
                createTablesCommand.ExecuteNonQuery();
            }
        }
    }
}
using System.Data.SqlClient;
using System.IO;

public class StartUp
{
    public static void Main()
    {
        var connection = new SqlConnection(@"Data Source = .; Integrated Security = true");
        connection.Open();
        using (connection)
        {
            ExecuteCommand("CreateDatabase", connection);
        }

        connection = new SqlConnection(
            @"Data Source = .; Integrated Security = true; Database = MinionsDB");
        connection.Open();
        using (connection)
        {
            var commands = new[]
            {
                "CreateCountries",
                "CreateTowns",
                "CreateMinions",
                "CreateEvilnessFactors",
                "CreateVillains",
                "CreateMinionsVillains",
                "InsertCountries",
                "InsertTowns",
                "InsertMinions",
                "InsertEvilnessFactors",
                "InsertVillains",
                "InsertMinionsVillains"
            };
            foreach (var command in commands)
            {
                ExecuteCommand(command, connection);
            }
        }
    }

    public static void ExecuteCommand(string commandName, SqlConnection connection)
    {
        var query = File.ReadAllText($@"sql\{commandName}.sql");
        var cmd = new SqlCommand(query, connection);
        cmd.ExecuteNonQuery();
    }
}
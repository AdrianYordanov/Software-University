using System;
using System.Data.SqlClient;
using System.IO;

public class StartUp
{
    public static void Main()
    {
        var connection = new SqlConnection(@"Data Source = DESKTOP-FPETI1U\SQLEXPRESS; Integrated Security = true; Database = MinionsDB");
        connection.Open();
        using (connection)
        {
            var command = GetCommand("GetVillains", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} - {reader["Minions Count"]}");
            }
        }
    }

    public static SqlCommand GetCommand(string commandName, SqlConnection connection)
    {
        var query = File.ReadAllText($@"sql\{commandName}.sql");
        var cmd = new SqlCommand(query, connection);
        return cmd;
    }
}
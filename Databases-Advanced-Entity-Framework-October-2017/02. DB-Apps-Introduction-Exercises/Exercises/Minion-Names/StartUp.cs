using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

public class StartUp
{
    public static void Main()
    {
        var connection = new SqlConnection(@"Data Source = .; Integrated Security = true; Database = MinionsDB");
        connection.Open();
        using (connection)
        {
            Console.Write("Villain id: ");
            var villainId = int.Parse(Console.ReadLine());
            var command = GetCommand("GetVillain", connection);
            command.Parameters.AddWithValue("@villainId", villainId);
            var name = (string)command.ExecuteScalar();
            if (name == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                command = GetCommand("GetMinions", connection);
                command.Parameters.AddWithValue("@villainId", villainId);
                var reader = command.ExecuteReader();
                var minions = new List<string>();
                for (var i = 1; reader.Read(); i++)
                {
                    minions.Add($"{i}. {reader["Name"]} {reader["Age"]}");
                }

                Console.WriteLine(minions.Count == 0 ? "(no minions)" : string.Join(Environment.NewLine, minions));
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
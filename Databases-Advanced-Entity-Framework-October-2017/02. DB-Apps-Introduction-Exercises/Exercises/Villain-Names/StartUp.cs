using System;
using System.Data.SqlClient;

public class StartUp
{
    public static void Main()
    {
        var builder = new SqlConnectionStringBuilder
        {
            // Change '.' with the name of your SQL Server, if it doesn't work.
            ["Data Source"] = @"DESKTOP-FPETI1U\SQLEXPRESS",
            ["Integrated Security"] = true,
            ["initial catalog"] = "MinionsDB"
        };
        var connection = new SqlConnection(builder.ToString());
        connection.Open();
        using (connection)
        {
            try
            {
                var command = new SqlCommand(
                    "SELECT v.[Name], COUNT(*) AS [Minions Count] FROM Villains AS v\n" +
                    "INNER JOIN MinionsVillains AS mv ON mv.VillainId = v.Id\n" +
                    "GROUP BY v.[Name]\n" +
                    "HAVING COUNT(*) > 3\n" +
                    "ORDER BY[Minions Count] DESC\n",
                    connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]} - {reader["Minions Count"]}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
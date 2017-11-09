using System;
using System.Data.SqlClient;

public class StartUp
{
    public static void Main()
    {
        var builder = new SqlConnectionStringBuilder
        {
            // Change '.' with the name of your SQL Server, if it doesn't work.
            ["Data Source"] = @".",
            ["Integrated Security"] = true,
            ["initial catalog"] = "MinionsDB"
        };
        var connection = new SqlConnection(builder.ToString());
        connection.Open();
        using (connection)
        {
            try
            {
                var villainId = int.Parse(Console.ReadLine());
                var command = new SqlCommand("SELECT [Name] FROM Villains\n" + "WHERE Id = @villainId", connection);
                command.Parameters.AddWithValue("@villainId", villainId);
                var name = (string)command.ExecuteScalar();
                if (name == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                }
                else
                {
                    command.CommandText = "SELECT m.[Name], m.Age FROM Villains AS v\n" +
                                          "INNER JOIN MinionsVillains AS mv ON mv.VillainId = v.Id\n" +
                                          "INNER JOIN Minions AS m ON m.Id = mv.MinionId\n" +
                                          "WHERE v.Id = @villainId";
                    var reader = command.ExecuteReader();
                    if (!reader.Read())
                    {
                        Console.WriteLine("(no minions)");
                    }
                    else
                    {
                        reader.Dispose();
                        reader = command.ExecuteReader();
                        for (var i = 1; reader.Read(); i++)
                        {
                            Console.WriteLine($"{i}. {reader["Name"]} {reader["Age"]}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
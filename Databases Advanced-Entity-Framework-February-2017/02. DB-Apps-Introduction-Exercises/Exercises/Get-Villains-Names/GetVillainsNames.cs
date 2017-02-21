using System;
using System.Data.SqlClient;
using System.IO;

class GetVillainsNames
{
    static void Main()
    {
        string query = File.ReadAllText("../../queries/get-villains-names.sql");

        SqlConnection connection = new SqlConnection(@"Server=ASUS-ADRIAN\SQLEXPRESS;
Database=MinionsDB;
Integrated Security=true");

        connection.Open();

        using (connection)
        {
            SqlCommand command = new SqlCommand(query, connection);

            var reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                }
            }

        }
    }
}
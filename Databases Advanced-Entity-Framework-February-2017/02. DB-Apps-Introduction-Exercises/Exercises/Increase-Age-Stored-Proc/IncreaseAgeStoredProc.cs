using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

class IncreaseAgeStoredProc
{
    static void Main()
    {
        int minionId = int.Parse(Console.ReadLine());
        string getMinionQuery = File.ReadAllText("../../queries/get-minion.sql");

        using (SqlConnection connection = new SqlConnection(@"Server=ASUS-ADRIAN\SQLEXPRESS;
Database=MinionsDB;
Integrated Security=true"))
        {
            connection.Open();

            SqlCommand executeProcedureCommand = new SqlCommand("usp_GetOlder", connection)
            { CommandType = CommandType.StoredProcedure };
            executeProcedureCommand.Parameters.AddWithValue("@MinionId", minionId);
            executeProcedureCommand.ExecuteNonQuery();

            SqlCommand getMinionCommand = new SqlCommand(getMinionQuery, connection);
            getMinionCommand.Parameters.AddWithValue("@MinionId", minionId);
            var reader = getMinionCommand.ExecuteReader();

            reader.Read();
            Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
        }
    }
}
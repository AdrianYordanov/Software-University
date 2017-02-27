using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

class IncreaseMinionsAge
{
    static void Main()
    {
        List<int> minionsIds = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        string updateQuery = "UPDATE Minions\nSET Age += 1, Name = UPPER(LEFT(Name,1)) + LOWER(SUBSTRING(Name, 2, LEN(Name)))\n";
        string selectQuery = "SELECT Name, Age FROM Minions";
        string whereStatement = "WHERE Id IN(" +
            minionsIds.Select((id, index) => "@Id" + index).Aggregate((id1, id2) => id1 + ", " + id2) + ")";
        updateQuery += whereStatement;

        using (SqlConnection connection = new SqlConnection(@"Server=ASUS-ADRIAN\SQLEXPRESS;
Database=MinionsDB;
Integrated Security=true"))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(updateQuery, connection);

            for (int i = 0; i < minionsIds.Count; i++)
            {
                command.Parameters.AddWithValue("@Id" + i, minionsIds.ElementAt(i));
            }

            command.ExecuteNonQuery();
            command.CommandText = selectQuery;
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
            }
        }
    }
}
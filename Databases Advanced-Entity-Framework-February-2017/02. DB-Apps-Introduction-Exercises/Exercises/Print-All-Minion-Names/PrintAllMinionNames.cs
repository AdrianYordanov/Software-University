using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.IO;

class PrintAllMinionNames
{
    static void Main()
    {
        string getAllMinionNamesQuery = File.ReadAllText("../../queries/get-all-minion-names.sql");

        using (SqlConnection connection = new SqlConnection(@"Server=ASUS-ADRIAN\SQLEXPRESS;
Database=MinionsDB;
Integrated Security=true"))
        {
            connection.Open();

            SqlCommand command = new SqlCommand(getAllMinionNamesQuery, connection);
            List<string> namesCollection = new List<string>();
            List<string> sortedNamesCollection = new List<string>();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                namesCollection.Add(reader["Name"].ToString());
            }

            for (int fromBeginIndex = 0, fromEndIndex = namesCollection.Count - 1; fromBeginIndex <= fromEndIndex;
                fromBeginIndex++, --fromEndIndex)
            {
                if (fromBeginIndex == fromEndIndex)
                {
                    sortedNamesCollection.Add(namesCollection.ElementAt(fromBeginIndex));
                }
                else
                {
                    sortedNamesCollection.Add(namesCollection.ElementAt(fromBeginIndex));
                    sortedNamesCollection.Add(namesCollection.ElementAt(fromEndIndex));
                }
            }

            Console.WriteLine("Original order: ");
            Console.WriteLine(String.Join(", ", namesCollection));
            Console.WriteLine("Output: ");
            Console.WriteLine(String.Join(", ", sortedNamesCollection));
        }
    }
}
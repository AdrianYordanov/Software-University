using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GetMinionNames
{
    static void Main()
    {
        string getVillainNameQuery = File.ReadAllText("../../queries/get-villain-name.sql");
        string getMinionNamesQuery = File.ReadAllText("../../queries/get-minion-names.sql");

        SqlConnection connection = new SqlConnection(@"Server=ASUS-ADRIAN\SQLEXPRESS;
Database=MinionsDB;
Integrated Security=true");

        connection.Open();

        Console.Write("Enter villain id: ");
        int villainId = int.Parse(Console.ReadLine());

        using (connection)
        {
            SqlCommand villainNameCommand = new SqlCommand(getVillainNameQuery, connection);
            villainNameCommand.Parameters.AddWithValue("@VillainId", villainId);
            var villainName = villainNameCommand.ExecuteScalar();

            if (villainName != null)
            {
                Console.WriteLine($"Villain: {villainName}");

                SqlCommand minionNamesCommand = new SqlCommand(getMinionNamesQuery, connection);
                minionNamesCommand.Parameters.AddWithValue(@"VillainId", villainId);
                var reader = minionNamesCommand.ExecuteReader();

                using (reader)
                {
                    int miniosCounter = 1;

                    for (; reader.Read(); ++miniosCounter)
                    {
                        Console.WriteLine($"{miniosCounter}. {reader["MinionName"]} {reader["MinionAge"]}");
                    }

                    if (miniosCounter == 1)
                    {
                        Console.WriteLine("(no minions)");
                    }
                }
            }
            else
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return;
            }
        }
    }
}
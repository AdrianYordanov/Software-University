using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

class ChangeTownNamesCasing
{
    static void Main()
    {
        Console.Write("Enter country name: ");
        string countrySelected = Console.ReadLine();

        string getLowerCasingTownsQuery = File.ReadAllText("../../queries/get-lower-towns.sql");
        string changeTownsToUpperQuery = File.ReadAllText("../../queries/change-towns-to-upper-case.sql");

        using (SqlConnection connection = new SqlConnection(@"Server=ASUS-ADRIAN\SQLEXPRESS;
Database=MinionsDB;
Integrated Security=true"))
        {
            connection.Open();

            SqlCommand command = new SqlCommand(getLowerCasingTownsQuery, connection);
            command.Parameters.AddWithValue("@SelectedCountry", countrySelected);
            List<string> townsForChange = new List<string>();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                townsForChange.Add(reader["Name"].ToString().ToUpper());
            }

            reader.Close();

            if (townsForChange.Count == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                command.CommandText = changeTownsToUpperQuery;
                command.ExecuteNonQuery();
                Console.WriteLine($"{townsForChange.Count} town names were affected.");
                Console.WriteLine("[" + String.Join(", ", townsForChange) + "]");
            }
        }
    }
}
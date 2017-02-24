using System;
using System.Data.SqlClient;
using System.IO;

class AddMinion
{
    static void Main()
    {
        Console.Write("Minion: ");
        string[] tokens = Console.ReadLine().Split(' ');
        string minionName = tokens[0];
        int minionAge = int.Parse(tokens[1]);
        string minionTown = tokens[2];
        Console.Write("Villain: ");
        string villainName = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(@"Server=ASUS-ADRIAN\SQLEXPRESS;
Database=MinionsDB;
Integrated Security=true"))
        {
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            SqlTransaction transaction = connection.BeginTransaction("AddMinionTransaction");

            command.Connection = connection;
            command.Transaction = transaction;

            try
            {
                var townId = GetTownIdByName(command, minionTown);
                if (townId == null)
                {
                    AddTownInDatabase(command, minionTown);
                    townId = GetTownIdByName(command, minionTown);
                }

                var villainId = GetVillainByName(command, villainName);
                if (villainId == null)
                {
                    AddVillainInDtabase(command, villainName);
                    villainId = GetVillainByName(command, villainName);
                }

                AddMinionInDatabase(command, minionName, minionAge, townId);
                var minionId = GetMinionIdByName(command, minionName);

                MakeMinionServerVillain(command, minionId, villainId);
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
                transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                    Console.WriteLine("Transaction was rollbacked.");
                    Console.WriteLine($"Message: {ex.Message}");
                }
                catch (Exception transactionException)
                {
                    Console.WriteLine("Rollback Exception Type: {0}", transactionException.GetType());
                }
            }
        }
    }

    static void AddTownInDatabase(SqlCommand command, string townName)
    {
        command.Parameters.Clear();
        command.CommandText = File.ReadAllText("../../queries/add-town.sql");
        command.Parameters.AddWithValue("@TownNameForAdd", townName);
        command.ExecuteNonQuery();
        Console.WriteLine($"Town {townName} was added to the database.");
    }

    static int? GetTownIdByName(SqlCommand command, string townName)
    {
        command.Parameters.Clear();
        command.CommandText = File.ReadAllText("../../queries/get-town-by-name.sql");
        command.Parameters.AddWithValue("@TownNameForCheck", townName);
        return (int?)command.ExecuteScalar();
    }

    static void AddMinionInDatabase(SqlCommand command, string minionName, int minionAge, int? townId)
    {
        command.Parameters.Clear();
        command.CommandText = File.ReadAllText("../../queries/add-minion.sql");
        command.Parameters.AddWithValue("@MinionNameForAdd", minionName);
        command.Parameters.AddWithValue("@MinionAgeForAdd", minionAge);
        command.Parameters.AddWithValue("@MinionTownIdForAdd", townId);
        command.ExecuteNonQuery();
    }

    static int? GetMinionIdByName(SqlCommand command, string minionName)
    {
        command.Parameters.Clear();
        command.CommandText = File.ReadAllText("../../queries/get-minion-by-name.sql");
        command.Parameters.AddWithValue("@MinionNameForCheck", minionName);
        return (int?)command.ExecuteScalar();
    }

    static void AddVillainInDtabase(SqlCommand command, string villainName)
    {
        command.Parameters.Clear();
        command.CommandText = File.ReadAllText("../../queries/add-villain.sql");
        command.Parameters.AddWithValue("@VillainNameForAdd", villainName);
        command.ExecuteNonQuery();
        Console.WriteLine($"Villain {villainName} was added to the database.");
    }

    static int? GetVillainByName(SqlCommand command, string villainName)
    {
        command.Parameters.Clear();
        command.CommandText = File.ReadAllText("../../queries/get-villain-by-name.sql");
        command.Parameters.AddWithValue("@VillainNameForCheck", villainName);
        return (int?)command.ExecuteScalar();
    }

    static void MakeMinionServerVillain(SqlCommand command, int? minionId, int? villainId)
    {
        command.Parameters.Clear();
        command.CommandText = File.ReadAllText("../../queries/make-minion-serve-villain.sql");
        command.Parameters.AddWithValue("@MinionId", minionId);
        command.Parameters.AddWithValue("@VillainId", villainId);
        command.ExecuteNonQuery();
    }
}
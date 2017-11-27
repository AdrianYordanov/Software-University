using System;
using System.Data.SqlClient;
using System.IO;

public class StartUp
{
    public static void Main()
    {
        var connection = new SqlConnection(
            @"Data Source = .; Integrated Security = true; Database = MinionsDB");
        connection.Open();
        using (connection)
        {
            using (var transaction = connection.BeginTransaction())
            {
                var minionTokens = Console.ReadLine()
                    .Split(
                        new[]
                        {
                            ' ',
                            ':'
                        },
                        StringSplitOptions.RemoveEmptyEntries);
                var villainTokens = Console.ReadLine()
                    .Split(
                        new[]
                        {
                            ' ',
                            ':'
                        },
                        StringSplitOptions.RemoveEmptyEntries);
                var minionName = minionTokens[1];
                var minionAge = int.Parse(minionTokens[2]);
                var townName = minionTokens[3];
                var villainName = villainTokens[1];
                try
                {
                    TryAddTown(townName, connection, transaction);
                    TryAddVillain(villainName, connection, transaction);
                    TryAddMinion(minionName, minionAge, townName, connection, transaction);
                    TryAddRelation(minionName, villainName, connection, transaction);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                        Console.WriteLine("Rollback transaction.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Transaction error.");
                    }
                }
            }
        }
    }

    public static SqlCommand GetCommand(string commandName, SqlConnection connection)
    {
        var query = File.ReadAllText($@"sql\{commandName}.sql");
        var cmd = new SqlCommand(query, connection);
        return cmd;
    }

    public static void TryAddTown(string townName, SqlConnection connection, SqlTransaction transaction)
    {
        var getTownCommand = GetCommand("GetTown", connection);
        getTownCommand.Transaction = transaction;
        getTownCommand.Parameters.AddWithValue("@townName", townName);
        var foundTown = (string)getTownCommand.ExecuteScalar();
        if (foundTown != null)
        {
            return;
        }

        var addTownCommand = GetCommand("AddTown", connection);
        addTownCommand.Transaction = transaction;
        addTownCommand.Parameters.AddWithValue("@townName", townName);
        addTownCommand.ExecuteNonQuery();
        Console.WriteLine($"Town {townName} was added to the database.");
    }

    public static void TryAddVillain(string villainName, SqlConnection connection, SqlTransaction transaction)
    {
        var getVillainCommand = GetCommand("GetVillain", connection);
        getVillainCommand.Transaction = transaction;
        getVillainCommand.Parameters.AddWithValue("@villainName", villainName);
        var foundVillain = (string)getVillainCommand.ExecuteScalar();
        if (foundVillain != null)
        {
            return;
        }

        var addVillainCommand = GetCommand("AddVillain", connection);
        addVillainCommand.Transaction = transaction;
        addVillainCommand.Parameters.AddWithValue("@villainName", villainName);
        addVillainCommand.ExecuteNonQuery();
        Console.WriteLine($"Villain {villainName} was added to the database.");
    }

    public static void TryAddMinion(
        string minionName,
        int minionAge,
        string townName,
        SqlConnection connection,
        SqlTransaction transaction)
    {
        var getMinionCommand = GetCommand("GetMinion", connection);
        getMinionCommand.Transaction = transaction;
        getMinionCommand.Parameters.AddWithValue("@minionName", minionName);
        var foundMinion = (string)getMinionCommand.ExecuteScalar();
        if (foundMinion != null)
        {
            return;
        }

        var addMinionCommand = GetCommand("AddMinion", connection);
        addMinionCommand.Transaction = transaction;
        addMinionCommand.Parameters.AddWithValue("@minionName", minionName);
        addMinionCommand.Parameters.AddWithValue("@minionAge", minionAge);
        addMinionCommand.Parameters.AddWithValue("@townName", townName);
        addMinionCommand.ExecuteNonQuery();
    }

    public static void TryAddRelation(
        string minionName,
        string villainName,
        SqlConnection connection,
        SqlTransaction transaction)
    {
        var addRelationCommand = GetCommand("AddRelation", connection);
        addRelationCommand.Transaction = transaction;
        addRelationCommand.Parameters.AddWithValue("@minionName", minionName);
        addRelationCommand.Parameters.AddWithValue("@villainName", villainName);
        addRelationCommand.ExecuteNonQuery();
        Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
    }
}
using System;
using System.Data.SqlClient;
using System.IO;

class RemoveVillain
{
    static void Main()
    {

        Console.Write("Villain Id: ");
        int villainId = int.Parse(Console.ReadLine());

        using (SqlConnection connection = new SqlConnection(@"Server=ASUS-ADRIAN\SQLEXPRESS;
Database=MinionsDB;
Integrated Security=true"))
        {
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            SqlTransaction transaction = connection.BeginTransaction("DeleteVillainTransaction");

            command.Connection = connection;
            command.Transaction = transaction;

            try
            {
                command.CommandText = File.ReadAllText("../../queries/get-villain-name.sql");
                command.Parameters.AddWithValue("@VillainId", villainId);

                if (command.ExecuteScalar() == null)
                {
                    Console.WriteLine("No such villain was found");
                    return;
                }

                string villainName = command.ExecuteScalar().ToString();

                command.CommandText = File.ReadAllText("../../queries/release-minions.sql");
                int releasedMinionsCount = command.ExecuteNonQuery();

                command.CommandText = File.ReadAllText("../../queries/delete-villain.sql");
                command.ExecuteNonQuery();

                transaction.Commit();

                Console.WriteLine($"{villainName} was deleted");
                Console.WriteLine($"{releasedMinionsCount} minions released");
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
}
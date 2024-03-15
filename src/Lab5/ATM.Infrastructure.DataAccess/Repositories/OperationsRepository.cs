using AutomatedTellerMachine.Abstractions.Repositories;
using AutomatedTellerMachine.Models;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace ATM.Infrastructure.DataAccess.Repositories;

public class OperationsRepository : IOperationsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationsRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<Operation> GetOperationsByAccount(long id)
    {
        const string sql = @"SELECT * FROM operations WHERE account_id = @AccountId";

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();

        var operations = new List<Operation>();

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@AccountId", id);

            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Assuming 'Operation' has properties corresponding to your table columns
                    var operation = new Operation((long)reader["account_id"], (double)reader["amount"]);

                    operations.Add(operation);
                }
            }
        }

        return operations;
    }

    public void AddOperation(long id, double amount)
    {
        const string sql = @"INSERT INTO operations (account_id, amount) 
            VALUES (@AccountID, @Amount) 
           ";

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@AccountId", id);
        command.Parameters.AddWithValue("@Amount", amount);

        command.ExecuteScalar();
    }
}
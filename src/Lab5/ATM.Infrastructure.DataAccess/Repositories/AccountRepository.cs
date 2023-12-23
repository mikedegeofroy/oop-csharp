using AutomatedTellerMachine.Abstractions.Repositories;
using AutomatedTellerMachine.Models;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace ATM.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public double GetBalanceByAccountId(long id)
    {
        const string sql = @"
            SELECT balance FROM accounts WHERE account_id = @AccountId";

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@AccountId", id);

        object? result = command.ExecuteScalar();

        return result != null ? (double)result : 0;
    }

    public void Debit(long id, double amount)
    {
        const string sql = @"
            UPDATE accounts SET balance = balance + @Amount WHERE account_id = @AccountId";

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@AccountId", id);
        command.Parameters.AddWithValue("@Amount", amount);

        command.ExecuteScalar();
    }

    public void Credit(long id, double amount)
    {
        const string sql = @"
            UPDATE accounts SET balance = balance - @Amount WHERE account_id = @AccountId";

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@AccountId", id);
        command.Parameters.AddWithValue("@Amount", amount);

        command.ExecuteScalar();
    }

    public Account CreateAccount(string hashedPin)
    {
        const string accountSql = @"
            INSERT INTO accounts (balance) 
            VALUES (@Balance) 
            RETURNING account_id;";

        const string passwordSql = @"
            INSERT INTO passwords (account_id, hash) 
            VALUES (@AccountId, @Hash);";

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();

        using NpgsqlTransaction transaction = connection.BeginTransaction();

        try
        {
            // Insert into accounts table
            using (var accountCommand = new NpgsqlCommand(accountSql, connection, transaction))
            {
                accountCommand.Parameters.AddWithValue("@Balance", 0);
                long accountId = (long)(accountCommand.ExecuteScalar() ?? 0);

                // Insert into passwords table
                using (var passwordCommand = new NpgsqlCommand(passwordSql, connection, transaction))
                {
                    passwordCommand.Parameters.AddWithValue("@AccountId", accountId);
                    passwordCommand.Parameters.AddWithValue("@Hash", hashedPin);
                    passwordCommand.ExecuteNonQuery();
                }

                transaction.Commit();
                return new Account(accountId);
            }
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw; // Re-throw the exception to be handled by the caller
        }
    }
}
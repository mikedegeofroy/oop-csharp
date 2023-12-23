using AutomatedTellerMachine.Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace ATM.Infrastructure.DataAccess.Repositories;

public class PinRepository : IPinRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;
    public PinRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public string GetPinHashByAccountId(long id)
    {
        const string sql = @"
            SELECT hash
            FROM passwords
            WHERE account_id = @UserId;";

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@UserId", id);

        object? result = command.ExecuteScalar();

        return result != null ? ((string)result).Trim() : string.Empty;
    }
}
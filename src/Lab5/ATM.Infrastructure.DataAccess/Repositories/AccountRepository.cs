using AutomatedTellerMachine.Abstractions.Repositories;
using AutomatedTellerMachine.Models;
using Itmo.Dev.Platform.Postgres.Connection;

namespace ATM.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Account GetAccountById(string id)
    {
        // const string sql = """
        //                    select shop_id, shop_name
        //                    from shops
        //                    """;
        //
        // NpgsqlConnection connection = _connectionProvider
        //     .GetConnectionAsync(default)
        //     .GetAwaiter()
        //     .GetResult();
        //
        // using var command = new NpgsqlCommand(sql, connection);
        // using NpgsqlDataReader reader = command.ExecuteReader();

        // while (reader.Read())
        // {
        //     yield return new Shop(
        //         reader.GetInt64(0),
        //         reader.GetString(1));
        // }
        return new Account("yes", 0);
    }

    public Account CreateAccount(string pin)
    {
        throw new NotImplementedException();
    }
}
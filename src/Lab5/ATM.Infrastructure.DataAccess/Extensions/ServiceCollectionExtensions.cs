using ATM.Infrastructure.DataAccess.Repositories;
using AutomatedTellerMachine.Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ATM.Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddScoped<IAccountRepository, AccountRepository>();
        collection.AddScoped<IOperationsRepository, OperationsRepository>();
        collection.AddScoped<IPinRepository, PinRepository>();

        return collection;
    }
}
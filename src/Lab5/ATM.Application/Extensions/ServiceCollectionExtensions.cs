using AutomatedTellerMachine.Abstractions.Auth;
using AutomatedTellerMachine.Application.Accounts;
using AutomatedTellerMachine.Application.Auth;
using AutomatedTellerMachine.Contracts.Accounts;
using Microsoft.Extensions.DependencyInjection;

namespace AutomatedTellerMachine.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IAuthenticationService, AuthenticationService>();

        return collection;
    }
}
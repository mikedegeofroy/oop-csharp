using ATM.Presentation.Console.CurrentAccount;
using ATM.Presentation.Console.Scenarios.Admin;
using ATM.Presentation.Console.Scenarios.Login;
using ATM.Presentation.Console.Scenarios.Menu;
using ATM.Presentation.Console.Scenarios.Register;
using Microsoft.Extensions.DependencyInjection;

namespace ATM.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RegisterScenarioProvider>();
        collection.AddScoped<IScenarioProvider, MenuScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminScenarioProvider>();
        collection.AddScoped<CurrentAccountService>();

        return collection;
    }
}
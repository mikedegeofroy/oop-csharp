using System.Diagnostics.CodeAnalysis;
using AutomatedTellerMachine.Contracts.Accounts;

namespace ATM.Presentation.Console.Scenarios.Login;

public class LoginScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;

    public LoginScenarioProvider(
        IAccountService service)
    {
        _service = service;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new LoginScenario(_service);
        return true;
    }
}
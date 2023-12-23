using System.Diagnostics.CodeAnalysis;
using ATM.Presentation.Console.CurrentAccount;
using AutomatedTellerMachine.Contracts.Accounts;

namespace ATM.Presentation.Console.Scenarios.Register;

public class RegisterScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly CurrentAccountService _currentAccountService;

    public RegisterScenarioProvider(
        IAccountService service, CurrentAccountService currentAccountService)
    {
        _service = service;
        _currentAccountService = currentAccountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccountService.CurrentAccount == null)
        {
            scenario = new RegisterScenario(_service, _currentAccountService);
            return true;
        }

        scenario = null;
        return false;
    }
}
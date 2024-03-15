using System.Diagnostics.CodeAnalysis;
using ATM.Presentation.Console.CurrentAccount;
using AutomatedTellerMachine.Contracts.Accounts;

namespace ATM.Presentation.Console.Scenarios.Admin;

public class AdminScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly CurrentAccountService _currentAccountService;

    public AdminScenarioProvider(
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
            // scenario = new AdminScenario(_service, _currentAccountService.CurrentAccount);
            // return true;
        }

        scenario = null;
        return false;
    }
}
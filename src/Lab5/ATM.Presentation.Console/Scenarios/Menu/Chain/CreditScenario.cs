using AutomatedTellerMachine.Contracts.Accounts;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.Menu.Chain;

public class CreditScenario : IScenario
{
    private readonly IAccountService _accountService;
    private readonly CurrentAccount.CurrentAccount _current;
    private IScenario? _nextScenario;

    public CreditScenario(IAccountService accountService, CurrentAccount.CurrentAccount current)
    {
        _accountService = accountService;
        _current = current;
    }

    public string Name => "Credit";

    public void Run()
    {
        double amount = AnsiConsole.Ask<double>("How much would you like to credit?\n");

        _accountService.Credit(amount, _current.Id, _current.Token);

        AnsiConsole.Clear();
        _nextScenario?.Run();
    }

    public void SetNext(IScenario scenario)
    {
        _nextScenario = scenario;
    }
}
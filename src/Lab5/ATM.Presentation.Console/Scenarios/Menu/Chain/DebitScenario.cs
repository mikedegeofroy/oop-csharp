using AutomatedTellerMachine.Contracts.Accounts;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.Menu.Chain;

public class DebitScenario : IScenario
{
    private readonly IAccountService _accountService;
    private readonly CurrentAccount.CurrentAccount _current;
    private IScenario? _nextScenario;

    public DebitScenario(IAccountService accountService, CurrentAccount.CurrentAccount current)
    {
        _accountService = accountService;
        _current = current;
    }

    public string Name => "Debit";

    public void Run()
    {
        double amount = AnsiConsole.Ask<double>("How much would you like to credit?\n");

        _accountService.Debit(amount, _current.Id, _current.Token);

        AnsiConsole.Clear();
        _nextScenario?.Run();
    }

    public void SetNext(IScenario scenario)
    {
        _nextScenario = scenario;
    }
}
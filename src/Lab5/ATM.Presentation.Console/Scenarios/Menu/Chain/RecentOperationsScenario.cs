using System.Globalization;
using System.Text;
using AutomatedTellerMachine.Contracts.Accounts;
using AutomatedTellerMachine.Models;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.Menu.Chain;

public class RecentOperationsScenario : IScenario
{
    private readonly IAccountService _accountService;
    private readonly CurrentAccount.CurrentAccount _current;
    private IScenario? _nextScenario;

    public RecentOperationsScenario(IAccountService accountService, CurrentAccount.CurrentAccount current)
    {
        _accountService = accountService;
        _current = current;
    }

    public string Name => "Recent Operations";

    public void Run()
    {
        IEnumerable<Operation> operations = _accountService.GetOperations(_current.Id, _current.Token);

        AnsiConsole.WriteLine("Recent Operations:");

        var sb = new StringBuilder();

        foreach (Operation operation in operations)
        {
            sb.AppendLine(operation.Amount.ToString(CultureInfo.CurrentCulture));
        }

        AnsiConsole.WriteLine(sb.ToString());

        AnsiConsole.Console.Input.ReadKey(false);
        AnsiConsole.Clear();
        _nextScenario?.Run();
    }

    public void SetNext(IScenario scenario)
    {
        _nextScenario = scenario;
    }
}
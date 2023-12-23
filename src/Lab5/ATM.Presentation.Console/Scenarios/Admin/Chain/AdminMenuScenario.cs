using System.Text;
using AutomatedTellerMachine.Contracts.Accounts;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.Admin.Chain;

public class AdminMenuScenario : IScenario
{
    private readonly List<IScenario> _scenarios = new();
    private readonly IAccountService _accountService;
    private readonly CurrentAccount.CurrentAccount _current;

    public AdminMenuScenario(IAccountService accountService, CurrentAccount.CurrentAccount current)
    {
        _accountService = accountService;
        _current = current;
    }

    public string Name => "Menu";

    public void Run()
    {
        var sb = new StringBuilder();
        sb.Append("Current Balance: ");
        sb.Append(_accountService.GetBalance(_current.Id, _current.Token));

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title(sb.ToString())
            .AddChoices(_scenarios)
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }

    public void SetNext(IScenario scenario)
    {
        _scenarios.Add(scenario);
    }
}
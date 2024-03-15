using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using ATM.Presentation.Console.CurrentAccount;
using AutomatedTellerMachine.Contracts.Accounts;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.Register;

public class RegisterScenario : IScenario
{
    private readonly IAccountService _accountService;
    private readonly CurrentAccountService _currentAccountService;

    public RegisterScenario(IAccountService accountService, CurrentAccountService currentAccountService)
    {
        _accountService = accountService;
        _currentAccountService = currentAccountService;
    }

    public string Name => "Register";

    public void Run()
    {
        string pin1 = AnsiConsole.Ask<string>("Enter your pin: ");
        string pin2 = AnsiConsole.Ask<string>("Re-enter your pin: ");

        if (pin1 != pin2) Run();

        string hashedPin = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(pin1)));

        long id = _accountService.Create(hashedPin);

        AnsiConsole.WriteLine(id.ToString(CultureInfo.CurrentCulture));
    }

    public void SetNext(IScenario scenario)
    {
        throw new NotImplementedException();
    }
}
using System.Security.Cryptography;
using System.Text;
using ATM.Presentation.Console.CurrentAccount;
using AutomatedTellerMachine.Contracts.Accounts;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IAccountService _accountService;
    private readonly CurrentAccountService _currentAccountService;

    public LoginScenario(IAccountService accountService, CurrentAccountService currentAccountService)
    {
        _accountService = accountService;
        _currentAccountService = currentAccountService;
    }

    public string Name => "Login";

    public void Run()
    {
        long account = AnsiConsole.Ask<long>("Enter your account");
        string pin = AnsiConsole.Ask<string>("Enter your pin");

        string hashedPin = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(pin)));

        LoginResult result = _accountService.Login(account, hashedPin);

        switch (result)
        {
            case LoginResult.Success success:
                AnsiConsole.WriteLine("Login successful.");
                _currentAccountService.CurrentAccount = new CurrentAccount.CurrentAccount(account, success.Token);
                break;
            case LoginResult.NotFound:
                AnsiConsole.WriteLine("Account not found or incorrect password.");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(result));
        }
    }

    public void SetNext(IScenario scenario)
    {
        throw new NotImplementedException();
    }
}
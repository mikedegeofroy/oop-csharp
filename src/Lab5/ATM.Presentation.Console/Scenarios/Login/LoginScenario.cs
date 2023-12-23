using AutomatedTellerMachine.Contracts.Accounts;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IAccountService _accountService;

    public LoginScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Login";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");

        _accountService.Login(username, "123");

        // var message = result switch
        // {
        //     LoginResult.Success => "Successful login",
        //     LoginResult.NotFound => "User not found",
        //     _ => throw new ArgumentOutOfRangeException(nameof(result)),
        // };
        string message = "success!";

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}
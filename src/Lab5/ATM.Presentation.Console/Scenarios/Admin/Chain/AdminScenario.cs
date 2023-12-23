using ATM.Presentation.Console.CurrentAccount;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.Admin.Chain;

public class AdminScenario : IScenario
{
    private readonly CurrentAccountService _currentAccountService;

    public AdminScenario(CurrentAccountService currentAccountService)
    {
        _currentAccountService = currentAccountService;
    }

    public string Name => "Admin";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter admin password: ");

        // string hashedPass = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));

        // LoginResult result = _adminService.AdminLogin(hashedPass);
        // switch (result)
        // {
        //     case LoginResult.Success success:
        //         _currentAccountService.CurrentAccount = new CurrentAccount.CurrentAccount(0, success.Token);
        //         break;
        //     case LoginResult.NotFound:
        //         break;
        // }
        AnsiConsole.WriteLine(password);
    }

    public void SetNext(IScenario scenario)
    {
        throw new NotImplementedException();
    }
}
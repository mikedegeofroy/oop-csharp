namespace AutomatedTellerMachine.Contracts.Accounts;

public interface IAccountService
{
    LoginResult Login(string id, string pin);

    double GetBalance(string id, string token);
    string Create(string pin);
}
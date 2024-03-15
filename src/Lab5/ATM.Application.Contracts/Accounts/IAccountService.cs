using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Contracts.Accounts;

public interface IAccountService
{
    LoginResult Login(long id, string hashedPin);

    double GetBalance(long id, string token);

    OperationResult Credit(double amount, long id, string token);
    OperationResult Debit(double amount, long id, string token);

    IEnumerable<Operation> GetOperations(long id, string token);
    long Create(string hashedPin);
}
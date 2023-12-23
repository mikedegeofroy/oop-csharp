using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Abstractions.Repositories;

public interface IAccountRepository
{
    Account CreateAccount(string hashedPin);
    double GetBalanceByAccountId(long id);

    void Debit(long id, double amount);
    void Credit(long id, double amount);
}
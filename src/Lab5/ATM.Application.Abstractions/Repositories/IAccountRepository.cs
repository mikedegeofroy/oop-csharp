using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Abstractions.Repositories;

public interface IAccountRepository
{
    Account GetAccountById(string id);
    Account CreateAccount(string pin);
}
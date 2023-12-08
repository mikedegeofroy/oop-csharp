using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Contracts.Accounts;

public interface IAccountService
{
    IReadOnlyCollection<Operation> GetAllOperationsById(string id);
}
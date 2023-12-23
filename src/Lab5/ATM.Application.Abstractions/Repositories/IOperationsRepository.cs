using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Abstractions.Repositories;

public interface IOperationsRepository
{
    IEnumerable<Operation> GetOperationsByAccount(long id);
    void AddOperation(long id, double amount);
}
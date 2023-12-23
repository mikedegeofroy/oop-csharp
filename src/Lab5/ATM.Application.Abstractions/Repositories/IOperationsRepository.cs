using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Abstractions.Repositories;

public interface IOperationsRepository
{
    IEnumerable<Operation> GetOperationsByAccount(string id);
}
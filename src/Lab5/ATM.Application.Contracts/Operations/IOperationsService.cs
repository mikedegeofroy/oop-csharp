using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Contracts.Operations;

public interface IOperationsService
{
    IEnumerable<Operation> GetOperationsByAccount(string id, string token);
}
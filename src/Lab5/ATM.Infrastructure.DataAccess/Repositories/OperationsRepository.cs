using AutomatedTellerMachine.Abstractions.Repositories;
using AutomatedTellerMachine.Models;

namespace ATM.Infrastructure.DataAccess.Repositories;

public class OperationsRepository : IOperationsRepository
{
    public IEnumerable<Operation> GetOperationsByAccount(string id)
    {
        throw new NotImplementedException();
    }
}
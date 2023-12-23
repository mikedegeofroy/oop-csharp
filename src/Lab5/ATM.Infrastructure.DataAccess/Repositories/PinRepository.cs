using AutomatedTellerMachine.Abstractions.Repositories;

namespace ATM.Infrastructure.DataAccess.Repositories;

public class PinRepository : IPinRepository
{
    public string GetPinHashByUserId(string id)
    {
        return string.Empty;
    }
}
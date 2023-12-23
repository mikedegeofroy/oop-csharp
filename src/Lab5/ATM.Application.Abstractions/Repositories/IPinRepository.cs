namespace AutomatedTellerMachine.Abstractions.Repositories;

public interface IPinRepository
{
    string GetPinHashByAccountId(long id);
}
namespace AutomatedTellerMachine.Abstractions.Repositories;

public interface IPinRepository
{
    string GetPinHashByUserId(string id);
}
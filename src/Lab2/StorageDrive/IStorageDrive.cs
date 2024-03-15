namespace Itmo.ObjectOrientedProgramming.Lab2.StorageDrive;

public interface IStorageDrive : IValidatable, IPowerManagement
{
    public int Capacity { get; }
    public ConnectorType ConnectorType { get; }
}
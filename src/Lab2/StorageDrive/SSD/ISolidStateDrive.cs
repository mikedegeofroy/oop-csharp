namespace Itmo.ObjectOrientedProgramming.Lab2.StorageDrive.SSD;

public interface ISolidStateDrive : IStorageDrive
{
    public int MaxSpeed { get; }
}
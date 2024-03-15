namespace Itmo.ObjectOrientedProgramming.Lab2.StorageDrive.HDD;

public interface IHardDiskDrive : IStorageDrive
{
    public int Rpm { get; }
}
namespace Itmo.ObjectOrientedProgramming.Lab2.StorageDrive.HDD;

public class BaseHardDiskDrive : IHardDiskDrive
{
    public BaseHardDiskDrive(int capacity, int rpm, int consumption)
    {
        Power = new Power(consumption);
        Capacity = capacity;
        Rpm = rpm;
    }

    public int Capacity { get; }
    public ConnectorType ConnectorType => ConnectorType.Sata;
    public int Rpm { get; }
    public Power Power { get; }

    public ValidationResult Validate()
    {
        return new ValidationResult.Success();
    }
}
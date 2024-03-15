namespace Itmo.ObjectOrientedProgramming.Lab2.StorageDrive.SSD;

public class BaseSolidStateDrive : ISolidStateDrive
{
    public BaseSolidStateDrive(int capacity, int maxSpeed, ConnectorType connectorType, int consumption)
    {
        Power = new Power(consumption);
        Capacity = capacity;
        ConnectorType = connectorType;
        MaxSpeed = maxSpeed;
    }

    public Power Power { get; }
    public int Capacity { get; }
    public ConnectorType ConnectorType { get; }
    public int MaxSpeed { get; }

    public ValidationResult Validate()
    {
        return new ValidationResult.Success();
    }
}
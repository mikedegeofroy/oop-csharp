namespace Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;

public class BaseGraphicsCard : IGraphicsCard
{
    private readonly int _consumption;
    public BaseGraphicsCard(int consumption, Dimensions dimensions, string pcieVersion, double clockRate, int memory)
    {
        _consumption = consumption;
        Dimensions = dimensions;
        PcieVersion = pcieVersion;
        ClockRate = clockRate;
        Memory = memory;
    }

    public Power Power => new(_consumption);

    public Dimensions Dimensions { get; }
    public string PcieVersion { get; }
    public double ClockRate { get; }
    public int Memory { get; }

    public ValidationResult Validate()
    {
        return new ValidationResult.Success();
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu;

public class BaseCpu : ICpu
{
    public BaseCpu(CpuSocket socket, int coreCount, double coreFrequency, bool integratedGraphics, int heatGeneration, int memSpeed, int consumption)
    {
        Socket = socket;
        CoreCount = coreCount;
        ClockRate = coreFrequency;
        IntegratedGraphics = integratedGraphics;
        HeatGeneration = heatGeneration;
        Power = new Power(consumption);
        MemSpeed = memSpeed;
    }

    public CpuSocket Socket { get; }
    public int CoreCount { get; }
    public double ClockRate { get; }
    public int MemSpeed { get; }
    public bool IntegratedGraphics { get; }
    public int HeatGeneration { get; }
    public Power Power { get; }

    public ValidationResult Validate()
    {
        return new ValidationResult.Success();
    }
}
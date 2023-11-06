namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public class BaseCpu : ICpu
{
    public BaseCpu(CpuSocket socket, int coreCount, double coreFrequency, bool integratedGraphics, int heatGeneration)
    {
        Socket = socket;
        CoreCount = coreCount;
        CoreFrequency = coreFrequency;
        IntegratedGraphics = integratedGraphics;
        HeatGeneration = heatGeneration;
    }

    public CpuSocket Socket { get; }
    public int CoreCount { get; }
    public double CoreFrequency { get; }
    public bool IntegratedGraphics { get; }
    public int HeatGeneration { get; }

    public ValidationResult Validate()
    {
        return new ValidationResult.Success();
    }
}
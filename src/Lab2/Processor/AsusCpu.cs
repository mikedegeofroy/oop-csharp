namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public class AsusCpu : ICpu
{
    public AsusCpu()
    {
        Socket = CpuSocket.Lga1151;
        CoreCount = 24;
        CoreFrequency = 2.6;
    }

    public CpuSocket Socket { get; }

    public int CoreCount { get; }

    public double CoreFrequency { get; }

    public bool IntegratedGraphics => true;
    public int HeatGeneration => 10;

    public ValidationResult Validate()
    {
        return new ValidationResult.Success();
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public interface ICpu : IValidatable
{
    public CpuSocket Socket { get; }

    public int CoreCount { get; }
    public double CoreFrequency { get; }
    public bool IntegratedGraphics { get; }
    public int HeatGeneration { get; }
}
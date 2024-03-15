namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu;

public interface ICpu : IValidatable, IPowerManagement
{
    public CpuSocket Socket { get; }

    public int CoreCount { get; }
    public double ClockRate { get; }
    public int MemSpeed { get; }
    public bool IntegratedGraphics { get; }
    public int HeatGeneration { get; }
}
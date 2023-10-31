using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public interface IMotherboard : IValidatable
{
    public FormFactor FormFactor { get; }
    public CpuSocket Socket { get; }
    public IProcessor? Processor { get; }
}
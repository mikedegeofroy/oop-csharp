namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public interface IProcessor : IValidatable
{
    public CpuSocket Socket { get; }
}
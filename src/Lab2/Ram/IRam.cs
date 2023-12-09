namespace Itmo.ObjectOrientedProgramming.Lab2.Ram;

public interface IRam : IValidatable, IPowerManagement
{
    public int Capacity { get; }
    public RamFormFactor FormFactor { get; }
    public string DdrVersion { get; }
    public MemoryProfile? MemoryProfile { get; }
}
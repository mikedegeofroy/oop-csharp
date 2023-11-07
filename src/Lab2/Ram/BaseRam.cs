namespace Itmo.ObjectOrientedProgramming.Lab2.Ram;

public class BaseRam : IRam
{
    public BaseRam(int capacity, RamFormFactor formFactor, string ddrVersion, int consumption, MemoryProfile? memoryProfile = null)
    {
        Capacity = capacity;
        Power = new Power(consumption);
        MemoryProfile = memoryProfile;
        DdrVersion = ddrVersion;
        FormFactor = formFactor;
    }

    public int Capacity { get; }
    public RamFormFactor FormFactor { get; }
    public string DdrVersion { get; }
    public MemoryProfile? MemoryProfile { get; }
    public Power Power { get; }

    public ValidationResult Validate()
    {
        return new ValidationResult.Success();
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public class BasePowerSupply : IPowerSupply
{
    public ValidationResult Validate()
    {
        return new ValidationResult.Success();
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public class BasePowerSupply : IPowerSupply
{
    public BasePowerSupply(int consumption, int provision)
    {
        Power = new Power(consumption, provision);
    }

    public Power Power { get; }

    public ValidationResult Validate()
    {
        return new ValidationResult.Success();
    }
}
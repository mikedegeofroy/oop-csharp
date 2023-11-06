using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Frame;

public class BasicFrame : IFrame
{
    private IMotherboard? _motherboard;
    public void SetMotherboard(IMotherboard? motherboard)
    {
        _motherboard = motherboard;
    }

    public ValidationResult Validate()
    {
        // TODO
        // Add graphics card check
        return _motherboard == null ? new ValidationResult.Failure("No motherboard available") : _motherboard.Validate();
    }
}
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Frame;

public class BasicFrame : IFrame
{
    private IMotherboard? _motherboard;
    public void SetMotherboard(IMotherboard? motherboard)
    {
        _motherboard = motherboard;
    }

    public Result Validate()
    {
        // TODO
        // Add graphics card check
        return _motherboard == null ? new Result.Failure("No motherboard available") : _motherboard.Validate();
    }
}
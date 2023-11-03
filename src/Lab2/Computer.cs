using Itmo.ObjectOrientedProgramming.Lab2.Frame;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Computer : IValidatable
{
    private IFrame _frame;

    public Computer(IFrame frame)
    {
        _frame = frame;
    }

    public Result Validate()
    {
        return _frame.Validate();
    }
}
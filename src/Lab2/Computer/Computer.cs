using Itmo.ObjectOrientedProgramming.Lab2.Frame;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public class Computer
{
    private IFrame _frame;

    public Computer(IFrame frame)
    {
        _frame = frame;
    }
}
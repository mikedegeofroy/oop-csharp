using Itmo.ObjectOrientedProgramming.Lab2.Frame;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public class Computer
{
    public Computer(IFrame frame)
    {
        Frame = frame;
    }

    public IFrame Frame { get; }
}
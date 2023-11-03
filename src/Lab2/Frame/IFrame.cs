using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Frame;

public interface IFrame : IValidatable
{
    public void SetMotherboard(IMotherboard? motherboard);
}
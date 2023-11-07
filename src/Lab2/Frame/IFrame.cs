using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Frame;

public interface IFrame : IValidatable, IPowerManagement
{
    public Dimensions MaxDimensions { get; }

    public IMotherboard? Motherboard { get; }

    public IReadOnlyList<MotherboardFormFactor> SupportedFormFactors { get; }
    public void SetMotherboard(IMotherboard? motherboard);
}
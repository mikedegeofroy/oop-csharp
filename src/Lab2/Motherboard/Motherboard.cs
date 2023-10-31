using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class Motherboard : IMotherboard
{
    public Motherboard(IProcessor processor)
    {
        Processor = processor;

        FormFactor = FormFactor.MicroAtx;
        Socket = CpuSocket.Lga1151;
    }

    public FormFactor FormFactor { get; }

    public CpuSocket Socket { get; }
    public IProcessor? Processor { get; }

    public bool Validate()
    {
        var valid = new List<bool?>
        {
            Processor?.Validate(),
        };
        return valid.All(x => x is true or null);
    }
}
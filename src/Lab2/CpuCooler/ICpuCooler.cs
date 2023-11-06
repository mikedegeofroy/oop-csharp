using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.CpuCooler;

public interface ICpuCooler : IValidatable
{
    public Dimensions Dimensions { get; }

    public int HeatDissipation { get; }
    public ReadOnlyCollection<CpuSocket> SupportedSockets { get; }
}
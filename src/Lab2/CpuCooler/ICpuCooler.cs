using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.CpuCooler;

public interface ICpuCooler : IValidatable, IPowerManagement
{
    public Dimensions Dimensions { get; }

    public int HeatDissipation { get; }
    public ReadOnlyCollection<CpuSocket> SupportedSockets { get; }
}
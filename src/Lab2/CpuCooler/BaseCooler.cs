using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.CpuCooler;

public class BaseCooler : ICpuCooler
{
    public BaseCooler(Dimensions dimensions, int heatDissipation, ReadOnlyCollection<CpuSocket> supportedSockets, int consumption)
    {
        Dimensions = dimensions;
        HeatDissipation = heatDissipation;
        SupportedSockets = supportedSockets;
        Power = new Power(consumption);
    }

    public Power Power { get; }

    public Dimensions Dimensions { get; }
    public int HeatDissipation { get; }
    public ReadOnlyCollection<CpuSocket> SupportedSockets { get; }
    public ValidationResult Validate()
    {
        return new ValidationResult.Success();
    }
}
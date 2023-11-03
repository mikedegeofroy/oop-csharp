using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public interface IMotherboard : IValidatable
{
    public FormFactor FormFactor { get; }
    public CpuSocket Socket { get; }
    public IProcessor? Processor { get; }

    public void SetBios(IBios? bios);
    public void SetProcessor(IProcessor? processor);
    public void SetPowerSupply(IPowerSupply? powerSupply);
    public void SetGraphicsCard(IGraphicsCard? graphicsCard);
}
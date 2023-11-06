using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public interface IMotherboard : IValidatable
{
    public FormFactor FormFactor { get; }
    public CpuSocket Socket { get; }
    public ICpu? Cpu { get; }

    public void SetBios(IBios? bios);
    public void SetCpu(ICpu? processor);
    public void SetCpuCooler(ICpuCooler? cpuCooler);
    public void SetPowerSupply(IPowerSupply? powerSupply);
    public void SetGraphicsCard(IGraphicsCard? graphicsCard);
}
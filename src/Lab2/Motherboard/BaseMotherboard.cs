using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class BaseMotherboard : IMotherboard
{
    public BaseMotherboard(FormFactor formFactor, CpuSocket socket)
    {
        Cpu = null;
        GraphicsCard = null;

        FormFactor = formFactor;
        Socket = socket;
    }

    public FormFactor FormFactor { get; }
    public CpuSocket Socket { get; }
    public IBios? Bios { get; private set; }
    public ICpu? Cpu { get; private set; }

    public ICpuCooler? CpuCooler { get; private set; }
    public IGraphicsCard? GraphicsCard { get; private set; }
    public IPowerSupply? PowerSupply { get; private set; }
    public void SetBios(IBios? bios)
    {
        Bios = bios;
    }

    public void SetCpu(ICpu? processor)
    {
        Cpu = processor;
    }

    public void SetCpuCooler(ICpuCooler? cpuCooler)
    {
        CpuCooler = cpuCooler;
    }

    public void SetPowerSupply(IPowerSupply? powerSupply)
    {
        PowerSupply = powerSupply;
    }

    public void SetGraphicsCard(IGraphicsCard? graphicsCard)
    {
        GraphicsCard = graphicsCard;
    }

    public Result Validate()
    {
        // do this correctly
        Result valid = new Result.Success();

        // check cpu
        if (Cpu == null) return new Result.Failure("No available cpu");
        if (Cpu.Socket != Socket) valid = new Result.Failure("Incompatible motherboard and cpu socket");

        // check cpu cooler
        if (CpuCooler == null) return new Result.Failure("No available cooler");
        if (!CpuCooler.SupportedSockets.Contains(Cpu.Socket))
            return new Result.Failure("Cooler cant mount on cpu socket.");
        if (CpuCooler.HeatDissipation < Cpu.HeatGeneration) return new Result.Failure("Cooler can't handle cpu heat.");

        // check bios
        if (Bios == null) return new Result.Failure("No available bios");
        if (!Bios.SupportedProcessors.Contains(Cpu.GetType()))
            return new Result.Failure("Bios doesn't support cpu.");

        // check graphics card

        // check power supply
        return valid;
    }
}
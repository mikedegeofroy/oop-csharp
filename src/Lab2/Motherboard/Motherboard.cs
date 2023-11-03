using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class Motherboard : IMotherboard
{
    public Motherboard()
    {
        Processor = null;
        GraphicsCard = null;

        FormFactor = FormFactor.MicroAtx;
        Socket = CpuSocket.Lga1151;
    }

    public FormFactor FormFactor { get; }
    public CpuSocket Socket { get; }

    public IBios? Bios { get; private set; }
    public IProcessor? Processor { get; private set; }

    public IGraphicsCard? GraphicsCard { get; private set; }
    public IPowerSupply? PowerSupply { get; private set; }
    public void SetBios(IBios? bios)
    {
        Bios = bios;
    }

    public void SetProcessor(IProcessor? processor)
    {
        Processor = processor;
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

        if (Processor == null) return valid;
        if (Processor.Socket != Socket) valid = new Result.Failure("Incompatible socket");

        return valid;
    }
}
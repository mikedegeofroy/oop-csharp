using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Frame;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComputerBuilder
{
    private IFrame? _frame;
    private IMotherboard? _motherboard;
    private IPowerSupply? _powerSupply;
    private IBios? _bios;
    private ICpu? _processor;
    private IGraphicsCard? _graphicsCard;

    public ComputerBuilder SetMotherboard(IMotherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public ComputerBuilder SetBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public ComputerBuilder SetProcessor(ICpu cpu)
    {
        _processor = cpu;
        return this;
    }

    public ComputerBuilder SetPowerSupply(IPowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public ComputerBuilder SetGraphicsCard(IGraphicsCard graphicsCard)
    {
        _graphicsCard = graphicsCard;
        return this;
    }

    public ComputerBuilder SetFrame(IFrame frame)
    {
        _frame = frame;
        return this;
    }

    public Computer? Build()
    {
        if (_motherboard == null) return null;
        _motherboard.SetBios(_bios);
        _motherboard.SetCpu(_processor);
        _motherboard.SetGraphicsCard(_graphicsCard);
        _motherboard.SetPowerSupply(_powerSupply);

        if (_frame == null) return null;
        _frame.SetMotherboard(_motherboard);

        return _frame.Validate().ToBoolean() ? new Computer(_frame) : null;
    }
}

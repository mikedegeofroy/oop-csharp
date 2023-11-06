using System.IO.IsolatedStorage;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Frame;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Ram;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComputerBuilder
{
    private IFrame? _frame;
    private IMotherboard? _motherboard;
    private IPowerSupply? _powerSupply;
    private IBios? _bios;
    private ICpu? _processor;
    private IGraphicsCard? _graphicsCard;
    private IsolatedStorage? _drive;
    private IRam? _ram;

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

    public ComputerBuilder SetDrive(IsolatedStorage drive)
    {
        _drive = drive;
        return this;
    }

    public ComputerBuilder SetFrame(IRam ram)
    {
        _ram = ram;
        return this;
    }

    public ComputerBuilder SetFrame(IFrame frame)
    {
        _frame = frame;
        return this;
    }

    public BuildResult Build()
    {
        if (_motherboard == null) return new BuildResult.Failure("No available motherboard.");
        _motherboard.SetBios(_bios);
        _motherboard.SetCpu(_processor);
        _motherboard.SetGraphicsCard(_graphicsCard);
        _motherboard.SetPowerSupply(_powerSupply);

        if (_frame == null) return new BuildResult.Failure("No available frame.");
        _frame.SetMotherboard(_motherboard);

        ValidationResult validation = _frame.Validate();

        return validation switch
        {
            ValidationResult.Success => new BuildResult.Success("Build was successful", new Computer(_frame)),
            ValidationResult.Failure failure => new BuildResult.Failure(failure.Message),
            _ => new BuildResult.Failure("Unknown exception occured"),
        };
    }
}

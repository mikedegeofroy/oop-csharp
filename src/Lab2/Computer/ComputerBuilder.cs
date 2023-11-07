using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Frame;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.StorageDrive;
using Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public class ComputerBuilder
{
    private readonly List<IGraphicsCard> _graphicsCards;
    private readonly List<IStorageDrive> _drives;
    private readonly List<IRam> _ram;
    private IFrame? _frame;
    private IMotherboard? _motherboard;
    private IPowerSupply? _powerSupply;
    private IBios? _bios;
    private ICpu? _cpu;
    private IWifiAdapter? _wifiAdapter;

    public ComputerBuilder()
    {
        _graphicsCards = new List<IGraphicsCard>();
        _drives = new List<IStorageDrive>();
        _ram = new List<IRam>();
    }

    public ComputerBuilder(Computer computer)
        : this()
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer), "The computer argument cannot be null.");
        }

        _frame = computer.Frame;
        _motherboard = _frame.Motherboard;
        if (_motherboard == null) return;
        _graphicsCards = _motherboard.GraphicCards.ToList();
        _drives = _motherboard.StorageDrives.ToList();
        _ram = _motherboard.Ram.ToList();
        _powerSupply = _motherboard.PowerSupply;
        _bios = _motherboard.Bios;
        _cpu = _motherboard.Cpu;
        _wifiAdapter = _motherboard.WifiAdapter;
    }

    public static ComputerBuilder FromComputer(Computer computer)
    {
        return new ComputerBuilder(computer);
    }

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
        _cpu = cpu;
        return this;
    }

    public ComputerBuilder SetPowerSupply(IPowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public ComputerBuilder SetWifiAdapter(IWifiAdapter wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public ComputerBuilder AddGraphicsCard(IGraphicsCard graphicsCard)
    {
        _graphicsCards.Add(graphicsCard);
        return this;
    }

    public ComputerBuilder RemoveGraphicsCard(IGraphicsCard graphicsCard)
    {
        _graphicsCards.Remove(graphicsCard);
        return this;
    }

    public ComputerBuilder AddDrive(IStorageDrive drive)
    {
        _drives.Add(drive);
        return this;
    }

    public ComputerBuilder RemoveDrive(IStorageDrive drive)
    {
        _drives.Remove(drive);
        return this;
    }

    public ComputerBuilder AddRam(IRam ram)
    {
        _ram.Add(ram);
        return this;
    }

    public ComputerBuilder RemoveRam(IRam ram)
    {
        _ram.Remove(ram);
        return this;
    }

    public ComputerBuilder SetFrame(IFrame frame)
    {
        _frame = frame;
        return this;
    }

    public BuildResult Build()
    {
        if (_motherboard == null)
            return new BuildResult.Failure("No available motherboard.");
        _motherboard.SetBios(_bios);
        _motherboard.SetCpu(_cpu);
        _motherboard.SetPowerSupply(_powerSupply);
        _motherboard.SetGraphicCards(_graphicsCards.ToArray());
        _motherboard.SetStorageDrives(_drives.ToArray());
        _motherboard.SetWifiAdapter(_wifiAdapter);
        _motherboard.SetRam(_ram.ToArray());

        if (_frame == null)
            return new BuildResult.Failure("No available frame.");
        _frame.SetMotherboard(_motherboard);

        ValidationResult validation = _frame.Validate();

        if (_frame.Power.Consumption > _frame.Power.Provision)
            return new BuildResult.Failure("Not enough power!");

        return validation switch
        {
            ValidationResult.Success => new BuildResult.Success("Build was successful", new Computer(_frame)),
            ValidationResult.Warning warning => new BuildResult.Success(warning.Message, new Computer(_frame)),
            ValidationResult.Failure failure => new BuildResult.Failure(failure.Message),
            _ => new BuildResult.Failure("Unknown exception occured"),
        };
    }
}

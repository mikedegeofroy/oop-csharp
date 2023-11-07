using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.StorageDrive;
using Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public interface IMotherboard : IValidatable, IPowerManagement
{
    public MotherboardFormFactor MotherboardFormFactor { get; }
    public CpuSocket Socket { get; }
    public int PcieSlots { get; }
    public int SataSlots { get; }
    public int RamSlots { get; }
    public bool XmpCompatible { get; }

    public IBios? Bios { get; }
    public ICpu? Cpu { get; }
    public ICpuCooler? CpuCooler { get; }
    public IReadOnlyList<IGraphicsCard> GraphicCards { get; }
    public IPowerSupply? PowerSupply { get; }
    public IWifiAdapter? WifiAdapter { get; }
    public IReadOnlyList<IStorageDrive> StorageDrives { get; }
    public IReadOnlyList<IRam> Ram { get; }

    public void SetBios(IBios? bios);
    public void SetCpu(ICpu? processor);
    public void SetCpuCooler(ICpuCooler? cpuCooler);
    public void SetPowerSupply(IPowerSupply? powerSupply);
    public void SetWifiAdapter(IWifiAdapter? wifiAdapter);
    public void SetGraphicCards(params IGraphicsCard[] graphicCards);
    public void SetStorageDrives(params IStorageDrive[] storageDrives);
    public void SetRam(params IRam[] rams);
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.StorageDrive;
using Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class BaseMotherboard : IMotherboard
{
    private int _consumption;
    public BaseMotherboard(MotherboardFormFactor motherboardFormFactor, CpuSocket socket, int pcieSlots, int sataSlots, int ramSlots, bool xmpCompatible, int consumption)
    {
        Cpu = null;
        GraphicCards = new Collection<IGraphicsCard>();
        StorageDrives = new Collection<IStorageDrive>();
        Ram = new Collection<IRam>();

        MotherboardFormFactor = motherboardFormFactor;
        Socket = socket;
        PcieSlots = pcieSlots;
        SataSlots = sataSlots;
        RamSlots = ramSlots;
        XmpCompatible = xmpCompatible;
        _consumption = consumption;
    }

    public MotherboardFormFactor MotherboardFormFactor { get; }
    public CpuSocket Socket { get; }
    public int PcieSlots { get; private set; }
    public int SataSlots { get; private set; }
    public int RamSlots { get; private set; }
    public bool XmpCompatible { get; }
    public IBios? Bios { get; private set; }
    public ICpu? Cpu { get; private set; }
    public ICpuCooler? CpuCooler { get; private set; }
    public IPowerSupply? PowerSupply { get; private set; }
    public IWifiAdapter? WifiAdapter { get; private set; }
    public IReadOnlyList<IGraphicsCard> GraphicCards { get; private set; }
    public IReadOnlyList<IStorageDrive> StorageDrives { get; private set; }
    public IReadOnlyList<IRam> Ram { get; private set; }

    public Power Power
    {
        get
        {
            var powers = new List<Power>();
            if (Cpu != null) powers.Add(Cpu.Power);
            if (WifiAdapter != null) powers.Add(WifiAdapter.Power);
            if (CpuCooler != null) powers.Add(CpuCooler.Power);
            powers.AddRange(GraphicCards.Select(x => x.Power));
            powers.AddRange(StorageDrives.Select(x => x.Power));
            powers.AddRange(Ram.Select(x => x.Power));

            return new Power(powers);
        }
    }

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

    public void SetGraphicCards(params IGraphicsCard[] graphicCards)
    {
        GraphicCards = new List<IGraphicsCard>(graphicCards).ToArray();
        PcieSlots -= GraphicCards.Count;
    }

    public void SetStorageDrives(params IStorageDrive[] storageDrives)
    {
        StorageDrives = new List<IStorageDrive>(storageDrives).ToArray();
        foreach (IStorageDrive storageDrive in StorageDrives)
        {
            if (storageDrive.ConnectorType == ConnectorType.Sata) SataSlots--;
            else PcieSlots--;
        }
    }

    public void SetRam(params IRam[] rams)
    {
        Ram = new List<IRam>(rams).ToArray();
        RamSlots -= Ram.Count;
    }

    public void SetWifiAdapter(IWifiAdapter? wifiAdapter)
    {
        WifiAdapter = wifiAdapter;
    }

    public ValidationResult Validate()
    {
        var warnings = new List<string>();

        Func<ValidationResult>[] checkMethods = new[]
        {
            CheckCpuCompatibility,
            CheckCpuCoolerCompatibility,
            CheckBiosCompatibility,
            CheckGraphicsCardCompatibility,
            CheckStorage,
            CheckSlots,
            CheckXmpProfiles,
        };

        foreach (Func<ValidationResult> check in checkMethods)
        {
            ValidationResult result = check();
            switch (result)
            {
                case ValidationResult.Failure:
                    return result;
                case ValidationResult.Warning warning:
                    warnings.Add(warning.Message);
                    break;
            }
        }

        return warnings.Any() ? new ValidationResult.Warning(string.Join("\n", warnings)) : new ValidationResult.Success();
    }

    private ValidationResult CheckCpuCoolerCompatibility()
    {
        if (CpuCooler == null) return new ValidationResult.Failure("No available cooler");
        if (!CpuCooler.SupportedSockets.Contains(Socket))
            return new ValidationResult.Failure("Cooler cant mount on cpu socket.");
        if (Cpu != null && CpuCooler.HeatDissipation < Cpu.HeatGeneration) return new ValidationResult.Warning("Cooler can't handle cpu heat.");
        return CpuCooler.Validate();
    }

    private ValidationResult CheckCpuCompatibility()
    {
        if (Cpu == null) return new ValidationResult.Failure("No available cpu");
        return Cpu.Socket != Socket ? new ValidationResult.Failure("Incompatible motherboard and cpu socket") : Cpu.Validate();
    }

    private ValidationResult CheckBiosCompatibility()
    {
        if (Bios == null) return new ValidationResult.Failure("No available bios");
        if (Cpu != null && !Bios.SupportedProcessors.Contains(Cpu.GetType()))
            return new ValidationResult.Failure("Bios doesn't support cpu.");
        return new ValidationResult.Success();
    }

    private ValidationResult CheckGraphicsCardCompatibility()
    {
        if (GraphicCards.Count != 0) return new ValidationResult.Success();
        if (Cpu is { IntegratedGraphics: false })
            return new ValidationResult.Warning("No graphics available.");

        return new ValidationResult.Success();
    }

    private ValidationResult CheckSlots()
    {
        if (PcieSlots < 0) return new ValidationResult.Failure("Not enough pcie slots.");
        if (SataSlots < 0) return new ValidationResult.Failure("Not enough sata slots.");
        if (RamSlots < 0) return new ValidationResult.Failure("Not enough ram slots.");
        return new ValidationResult.Success();
    }

    private ValidationResult CheckStorage()
    {
        if (StorageDrives.Any()) return new ValidationResult.Success();
        return new ValidationResult.Failure("No available storage device.");
    }

    private ValidationResult CheckXmpProfiles()
    {
        IEnumerable<bool> xmpRam = Ram.Select(x => x.MemoryProfile != null);
        if (!xmpRam.Any()) return new ValidationResult.Success();
        if (!XmpCompatible) return new ValidationResult.Failure("Motherboard not xmp compatible");
        return new ValidationResult.Success();
    }
}
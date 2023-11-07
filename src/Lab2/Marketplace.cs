using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Frame;
using Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.StorageDrive;
using Itmo.ObjectOrientedProgramming.Lab2.StorageDrive.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.StorageDrive.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public static class Marketplace
{
    static Marketplace()
    {
        Motherboards = new Dictionary<string, IMotherboard>()
        {
            { "ATX_Gaming", new BaseMotherboard(MotherboardFormFactor.StandardAtx, CpuSocket.Lga1151, 4, 6, 4, true, 75) },
            { "MiniATX_Office", new BaseMotherboard(MotherboardFormFactor.MniAtx, CpuSocket.Lga2011, 2, 4, 4, true, 40) },
            { "NanoAtx_Workstation", new BaseMotherboard(MotherboardFormFactor.NanoAtx, CpuSocket.SocketAm2, 7, 10, 8, false, 100) },
            { "ATX_Budget", new BaseMotherboard(MotherboardFormFactor.StandardAtx, CpuSocket.Socket939, 2, 2, 2, false, 50) },
        };

        Processors = new Dictionary<string, ICpu>()
        {
            { "Workstation_Lga2011", new BaseCpu(CpuSocket.Lga2011, 12, 2.3, false, 130, 3600, 250) },
            { "Gaming_SocketAm4", new BaseCpu(CpuSocket.SocketAm4, 6, 3.7, true, 95, 3600, 95) },
            { "Legacy_Socket939", new BaseCpu(CpuSocket.Socket939, 2, 2.8, false, 89, 3600, 89) },
            { "Server_Lga1151", new BaseCpu(CpuSocket.Lga1151, 8, 2.7, false, 80, 3200, 120) },
            { "Budget_SocketAm2", new BaseCpu(CpuSocket.SocketAm2, 4, 3.0, false, 62, 1600, 62) },
            { "HighPerformance_Socket940", new BaseCpu(CpuSocket.Socket940, 4, 2.4, false, 95, 3200, 180) },
        };

        Coolers = new Dictionary<string, ICpuCooler>()
        {
            { "HighPerformance", new BaseCooler(new Dimensions(120, 120, 25), 250, new ReadOnlyCollection<CpuSocket>(new List<CpuSocket> { CpuSocket.Lga1151, CpuSocket.Lga2011, CpuSocket.SocketAm4 }), 5) },
            { "MidRange", new BaseCooler(new Dimensions(92, 92, 25), 180, new ReadOnlyCollection<CpuSocket>(new List<CpuSocket> { CpuSocket.SocketAm2, CpuSocket.SocketAm4 }), 3) },
            { "Budget", new BaseCooler(new Dimensions(80, 80, 15), 120, new ReadOnlyCollection<CpuSocket>(new List<CpuSocket> { CpuSocket.Socket939, CpuSocket.SocketAm2 }), 2) },
            { "Legacy", new BaseCooler(new Dimensions(70, 70, 15), 100, new ReadOnlyCollection<CpuSocket>(new List<CpuSocket> { CpuSocket.Socket939, CpuSocket.Socket940 }), 1) },
        };

        GraphicsCards = new Dictionary<string, IGraphicsCard>()
        {
            { "HighEnd_Gaming", new BaseGraphicsCard(250, new Dimensions(270, 120, 35), "PCIe 4.0", 1.8, 8192) },
            { "MidRange_Gaming", new BaseGraphicsCard(150, new Dimensions(240, 110, 35), "PCIe 3.0", 1.4, 4096) },
            { "Budget_Gaming", new BaseGraphicsCard(75, new Dimensions(170, 105, 30), "PCIe 3.0", 1.1, 2048) },
            { "Workstation", new BaseGraphicsCard(200, new Dimensions(280, 130, 40), "PCIe 4.0", 1.6, 16384) },
            { "HomeOffice", new BaseGraphicsCard(50, new Dimensions(160, 100, 30), "PCIe 2.0", 0.9, 1024) },
        };

        Bios = new Dictionary<string, IBios>()
        {
            { "UEFI_V1", new BaseBios("1.0.0", BiosType.UEFI) },
            { "Legacy_V1", new BaseBios("1.0.0", BiosType.Legacy) },
        };

        Ram = new Dictionary<string, IRam>()
        {
            {
                "HighPerformance_Desktop",
                new BaseRam(16, RamFormFactor.DIMM, "DDR4", 5, new MemoryProfile("16-18-18-36", 1.35, 3200))
            },
            {
                "Gaming_SODIMM",
                new BaseRam(8, RamFormFactor.SODIMM, "DDR4", 4, new MemoryProfile("19-19-19-43", 1.2, 2666))
            },
            {
                "Budget_Desktop",
                new BaseRam(4, RamFormFactor.DIMM, "DDR3", 3, new MemoryProfile("11-11-11-28", 1.5, 1333))
            },
            {
                "Workstation_ECC",
                new BaseRam(32, RamFormFactor.DIMM, "DDR4", 6, new MemoryProfile("16-16-16-32", 1.2, 2133))
            },
        };

        StorageDrives = new Dictionary<string, IStorageDrive>()
        {
            { "HDD_HighCapacity", new BaseHardDiskDrive(8000, 7200, 9) },
            { "HDD_MidCapacity", new BaseHardDiskDrive(2000, 5400, 6) },
            { "HDD_LowCapacity", new BaseHardDiskDrive(500, 5400, 3) },
            { "HDD_Performance", new BaseHardDiskDrive(1000, 10000, 12) },
            { "SSD_HighEnd_NVMe", new BaseSolidStateDrive(2000, 3500, ConnectorType.PciExpress, 8) },
            { "SSD_MidRange_SATA", new BaseSolidStateDrive(1000, 550, ConnectorType.Sata, 3) },
            { "SSD_Budget_SATA", new BaseSolidStateDrive(256, 550, ConnectorType.Sata, 2) },
            { "SSD_HighCapacity_NVMe", new BaseSolidStateDrive(4000, 3500, ConnectorType.PciExpress, 9) },
        };

        // Wifi Adapters
        WifiAdapters = new Dictionary<string, IWifiAdapter>()
        {
            { "Latest", new BaseWifiAdapter("Wi-Fi 6E", "PCIe 4.0", true, 5) },
            { "HighSpeed", new BaseWifiAdapter("Wi-Fi 6", "PCIe 3.0", true, 4) },
            { "MidRange", new BaseWifiAdapter("Wi-Fi 5", "PCIe 2.0", false, 3) },
            { "Budget", new BaseWifiAdapter("Wi-Fi 4", "PCIe 2.0", false, 2) },
        };

        // Psu
        PowerSupplies = new Dictionary<string, IPowerSupply>()
        {
            { "HighEnd_Gaming", new BasePowerSupply(15, 850) },
            { "MidRange_System", new BasePowerSupply(10, 650) },
            { "Budget_Build", new BasePowerSupply(5, 450) },
            { "Workstation", new BasePowerSupply(20, 1000) },
            { "EntryLevel", new BasePowerSupply(5, 350) },
        };

        // Cases
        Cases = new Dictionary<string, IFrame>()
        {
            { "FullTower", new BaseFrame(600, 230, new MotherboardFormFactor[] { MotherboardFormFactor.StandardAtx, MotherboardFormFactor.MniAtx, MotherboardFormFactor.MicroAtx }) },
            { "MidTower", new BaseFrame(450, 200, new MotherboardFormFactor[] { MotherboardFormFactor.StandardAtx, MotherboardFormFactor.MicroAtx }) },
            { "MiniTower", new BaseFrame(330, 180, new MotherboardFormFactor[] { MotherboardFormFactor.MniAtx, MotherboardFormFactor.NanoAtx }) },
            { "SlimDesktop", new BaseFrame(100, 380, new MotherboardFormFactor[] { MotherboardFormFactor.MicroAtx, MotherboardFormFactor.NanoAtx }) },
            { "Cube", new BaseFrame(400, 300, new MotherboardFormFactor[] { MotherboardFormFactor.StandardAtx, MotherboardFormFactor.MicroAtx, MotherboardFormFactor.NanoAtx }) },
        };
    }

    public static Dictionary<string, IMotherboard> Motherboards { get; private set; }

    public static Dictionary<string, ICpu> Processors { get; private set; }

    public static Dictionary<string, ICpuCooler> Coolers { get; private set; }

    public static Dictionary<string, IGraphicsCard> GraphicsCards { get; private set; }

    public static Dictionary<string, IBios> Bios { get; private set; }

    public static Dictionary<string, IRam> Ram { get; private set; }

    public static Dictionary<string, IStorageDrive> StorageDrives { get; private set; }

    public static Dictionary<string, IWifiAdapter> WifiAdapters { get; private set; }

    public static Dictionary<string, IPowerSupply> PowerSupplies { get; private set; }

    public static Dictionary<string, IFrame> Cases { get; private set; }
}
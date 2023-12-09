using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Frame;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.StorageDrive;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerBuilderTest
{
    [Fact]
    public void Build_Success_WhenComputerIsCompatible()
    {
        // Arrange
        IFrame frame = Marketplace.Cases["FullTower"];
        IMotherboard motherboard = Marketplace.Motherboards["ATX_Gaming"];
        ICpu cpu = Marketplace.Processors["Gaming_Lga1151"];
        ICpuCooler cooler = Marketplace.Coolers["HighPerformance"];
        IPowerSupply psu = Marketplace.PowerSupplies["HighEnd_Gaming"];
        IBios bios = Marketplace.Bios["UEFI_V1"];
        IStorageDrive storage = Marketplace.StorageDrives["HDD_HighCapacity"];

        var builder = new ComputerBuilder();

        // Act
        BuildResult result = builder
            .SetFrame(frame)
            .SetBios(bios)
            .SetMotherboard(motherboard)
            .SetCpu(cpu)
            .SetPowerSupply(psu)
            .SetCpuCooler(cooler)
            .AddDrive(storage)
            .Build();

        // Assert
        Assert.True(result is BuildResult.Success);
    }

    [Fact]
    public void Build_Warning_WhenPsuWeak()
    {
        // Arrange
        IFrame frame = Marketplace.Cases["FullTower"];
        IMotherboard motherboard = Marketplace.Motherboards["ATX_Gaming"];
        ICpu cpu = Marketplace.Processors["Gaming_Lga1151"];
        ICpuCooler cooler = Marketplace.Coolers["HighPerformance"];
        IPowerSupply psu = Marketplace.PowerSupplies["Legacy"];
        IBios bios = Marketplace.Bios["UEFI_V1"];
        IStorageDrive storage = Marketplace.StorageDrives["HDD_HighCapacity"];

        var builder = new ComputerBuilder();

        // Act
        BuildResult result = builder
            .SetFrame(frame)
            .SetBios(bios)
            .SetMotherboard(motherboard)
            .SetCpu(cpu)
            .SetPowerSupply(psu)
            .SetCpuCooler(cooler)
            .AddDrive(storage)
            .Build();

        // Assert
        Assert.True(result is BuildResult.Warning);
    }

    [Fact]
    public void Build_Warning_WhenCoolerWeakerThanCpu()
    {
        // Arrange
        IFrame frame = Marketplace.Cases["FullTower"];
        IMotherboard motherboard = Marketplace.Motherboards["ATX_Gaming"];
        ICpu cpu = Marketplace.Processors["Gaming_Lga1151"];
        ICpuCooler cooler = Marketplace.Coolers["Legacy"];
        IPowerSupply psu = Marketplace.PowerSupplies["HighEnd_Gaming"];
        IBios bios = Marketplace.Bios["UEFI_V1"];
        IStorageDrive storage = Marketplace.StorageDrives["HDD_HighCapacity"];

        var builder = new ComputerBuilder();

        // Act
        BuildResult result = builder
            .SetFrame(frame)
            .SetBios(bios)
            .SetMotherboard(motherboard)
            .SetCpu(cpu)
            .SetPowerSupply(psu)
            .SetCpuCooler(cooler)
            .AddDrive(storage)
            .Build();

        // Assert
        Assert.True(result is BuildResult.Warning);
    }

    [Fact]
    public void Build_Failure_WhenIncompatibleComponents()
    {
        // Arrange
        IFrame frame = Marketplace.Cases["SlimDesktop"];
        IMotherboard motherboard = Marketplace.Motherboards["ATX_Gaming"];
        ICpu cpu = Marketplace.Processors["Legacy_Socket939"];
        ICpuCooler cooler = Marketplace.Coolers["Legacy"];
        IPowerSupply psu = Marketplace.PowerSupplies["HighEnd_Gaming"];
        IBios bios = Marketplace.Bios["UEFI_V1"];

        var builder = new ComputerBuilder();

        // Act
        BuildResult result = builder
            .SetFrame(frame)
            .SetBios(bios)
            .SetMotherboard(motherboard)
            .SetCpu(cpu)
            .SetPowerSupply(psu)
            .SetCpuCooler(cooler)
            .Build();

        // Assert
        Assert.True(result is BuildResult.Failure);
    }
}
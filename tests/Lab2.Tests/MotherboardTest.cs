using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;
public class MotherboardTest
{
    [Fact]
    public void Validate_Warning_WhenCoolerIsWeakerThanCpu()
    {
        // Arrange
        var motherboard = new BaseMotherboard(FormFactor.MicroAtx, CpuSocket.Lga1151);

        motherboard.SetBios(new BiosBase("1", BiosType.UEFI));

        motherboard.SetCpu(new BaseCpu(CpuSocket.Lga1151, 4, 2.6, true, 10));

        motherboard.SetCpuCooler(new BaseCooler(new Dimensions(1, 1, 1), 5, new ReadOnlyCollection<CpuSocket>(new[] { CpuSocket.Lga1151 })));

        // Act
        ValidationResult result = motherboard.Validate();

        // Assert
        Assert.True(result is ValidationResult.Warning);
    }

    [Fact]
    public void Validate_Failed_WhenCpuIsNotAvailable()
    {
        // Arrange
        var motherboard = new BaseMotherboard(FormFactor.MicroAtx, CpuSocket.Lga1151);

        motherboard.SetBios(new BiosBase("1", BiosType.UEFI));

        motherboard.SetCpuCooler(new BaseCooler(new Dimensions(1, 1, 1), 5, new ReadOnlyCollection<CpuSocket>(new[] { CpuSocket.Lga1151 })));

        // Act
        ValidationResult result = motherboard.Validate();

        // Assert
        Assert.True(result is ValidationResult.Failure);
    }
}
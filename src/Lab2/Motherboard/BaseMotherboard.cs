using System;
using System.Collections.Generic;
using System.Linq;
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

    public ValidationResult Validate()
    {
        var warnings = new List<string>();

        var checkMethods = new Func<ValidationResult>[]
        {
            CheckCpuCompatibility,
            CheckCpuCoolerCompatibility,
            CheckBiosCompatibility,
            CheckGraphicsCardCompatibility,
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
        if (GraphicsCard != null) return new ValidationResult.Success();
        if (Cpu is { IntegratedGraphics: false })
            return new ValidationResult.Warning("No graphics available.");

        return new ValidationResult.Success();
    }
}
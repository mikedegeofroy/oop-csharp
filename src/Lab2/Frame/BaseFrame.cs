using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Frame;

public class BaseFrame : IFrame
{
    public BaseFrame(int height, int width, IEnumerable<MotherboardFormFactor> supportedFormFactors)
    {
        SupportedFormFactors = new List<MotherboardFormFactor>(supportedFormFactors).ToArray();
        MaxDimensions = new Dimensions(height, width, 50);
    }

    public IMotherboard? Motherboard { get; private set; }

    public Power Power => Motherboard != null ? Motherboard.Power : new Power(0);

    public Dimensions MaxDimensions { get; }
    public IReadOnlyList<MotherboardFormFactor> SupportedFormFactors { get; }

    public void SetMotherboard(IMotherboard? motherboard)
    {
        Motherboard = motherboard;
    }

    public ValidationResult Validate()
    {
        var warnings = new List<string>();

        var checkMethods = new Func<ValidationResult>[]
        {
            CheckAvailableMotherboard,
            CheckMotherboardFormFactor,
            CheckGpuDimensions,
            CheckPower,
        };

        foreach (Func<ValidationResult> check in checkMethods)
        {
            ValidationResult validationResult = check();
            switch (validationResult)
            {
                case ValidationResult.Failure:
                    return validationResult;
                case ValidationResult.Warning warning:
                    warnings.Add(warning.Message);
                    break;
            }
        }

        return warnings.Any() ? new ValidationResult.Warning(string.Join("\n", warnings)) : new ValidationResult.Success();
    }

    private ValidationResult CheckAvailableMotherboard()
    {
        return Motherboard == null ? new ValidationResult.Failure("No motherboard available") : Motherboard.Validate();
    }

    private ValidationResult CheckMotherboardFormFactor()
    {
        if (Motherboard == null) return new ValidationResult.Success();
        if (SupportedFormFactors.Contains(Motherboard.MotherboardFormFactor)) return new ValidationResult.Success();
        return new ValidationResult.Failure("Case doesn't support motherboard form factor");
    }

    private ValidationResult CheckGpuDimensions()
    {
        if (Motherboard == null) return new ValidationResult.Success();

        if (Motherboard.GraphicCards.Sum(x => x.Dimensions.Height) < MaxDimensions.Height
            && Motherboard.GraphicCards.Sum(x => x.Dimensions.Width) < MaxDimensions.Width)
            return new ValidationResult.Success();
        return new ValidationResult.Failure("Graphic cards don't fit in case.");
    }

    private ValidationResult CheckPower()
    {
        int powerGap = Power.Provision - Power.Consumption;
        return powerGap switch
        {
            >= 0 => new ValidationResult.Success(),
            < -50 => new ValidationResult.Failure("Not enough power!"),
            _ => new ValidationResult.Warning("Low power!"),
        };
    }
}
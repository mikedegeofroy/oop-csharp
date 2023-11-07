using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Frame;

public class BaseFrame : IFrame
{
    private IMotherboard? _motherboard;
    public BaseFrame(int height, int width, IEnumerable<MotherboardFormFactor> supportedFormFactors)
    {
        SupportedFormFactors = new List<MotherboardFormFactor>(supportedFormFactors).ToArray();
        MaxDimensions = new Dimensions(height, width, 50);
    }

    public Power Power => _motherboard != null ? _motherboard.Power : new Power(0);

    public Dimensions MaxDimensions { get; }
    public IReadOnlyList<MotherboardFormFactor> SupportedFormFactors { get; }

    public void SetMotherboard(IMotherboard? motherboard)
    {
        _motherboard = motherboard;
    }

    public ValidationResult Validate()
    {
        var warnings = new List<string>();

        var checkMethods = new Func<ValidationResult>[]
        {
            CheckAvailableMotherboard,
            CheckMotherboardFormFactor,
            CheckGpuDimensions,
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

    private ValidationResult CheckAvailableMotherboard()
    {
        return _motherboard == null ? new ValidationResult.Failure("No motherboard available") : _motherboard.Validate();
    }

    private ValidationResult CheckMotherboardFormFactor()
    {
        if (_motherboard == null) return new ValidationResult.Success();
        if (SupportedFormFactors.Contains(_motherboard.MotherboardFormFactor)) return new ValidationResult.Success();
        return new ValidationResult.Failure("Case doesn't support motherboard form factor");
    }

    private ValidationResult CheckGpuDimensions()
    {
        if (_motherboard == null) return new ValidationResult.Success();

        if (_motherboard.GraphicCards.Sum(x => x.Dimensions.Height) < MaxDimensions.Height
            && _motherboard.GraphicCards.Sum(x => x.Dimensions.Width) < MaxDimensions.Width)
            return new ValidationResult.Success();
        return new ValidationResult.Failure("Graphic cards don't fit in case.");
    }
}
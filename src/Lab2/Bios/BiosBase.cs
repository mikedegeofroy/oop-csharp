using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios;

public class BiosBase : IBios
{
    public BiosBase(string version, BiosType biosType)
    {
        var supportedProcessors = new List<Type>
        {
            typeof(BaseCpu),
        };

        Version = version;
        BiosType = biosType;
        SupportedProcessors = supportedProcessors.AsReadOnly();
    }

    public BiosType BiosType { get; }
    public ReadOnlyCollection<Type> SupportedProcessors { get; }
    public string Version { get; }
    public ValidationResult Validate()
    {
        return new ValidationResult.Success();
    }
}
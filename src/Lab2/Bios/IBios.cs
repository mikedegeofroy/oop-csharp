using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios;

public interface IBios : IValidatable
{
    public BiosType BiosType { get; }
    public ReadOnlyCollection<Type> SupportedProcessors { get; }
    public string Version { get; }
}
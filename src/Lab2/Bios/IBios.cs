using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios;

public interface IBios
{
    public BiosType Type { get; }
    public ReadOnlyCollection<Type> SupportedProcessors { get; }
    public string Version { get; }
}
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public record Path(string Value)
{
    public bool IsAbsolute => !Value.Any() || Value[0] == '/';
    public bool IsRelative => !IsAbsolute;
}
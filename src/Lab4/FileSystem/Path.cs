namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public record Path(string Value)
{
    public bool IsAbsolute => !IsRelative;
    public bool IsRelative => string.IsNullOrEmpty(Value) || Value[0] != '/';
}
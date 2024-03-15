namespace Itmo.ObjectOrientedProgramming.Lab2;

public record Dimensions(int Height, int Width, int Depth)
{
    public override string? ToString()
    {
        return base.ToString();
    }
}
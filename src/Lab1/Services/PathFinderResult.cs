using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public abstract record PathFinderResult
{
    public record Success(IShip Ship) : PathFinderResult;

    public record Failed : PathFinderResult;
}
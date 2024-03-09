using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Router;

public abstract record PathFinderResult
{
    public record Success(int Time, double Fuel, IShip Ship) : PathFinderResult;

    public record Failed : PathFinderResult;
}
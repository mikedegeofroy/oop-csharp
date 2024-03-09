using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Router;

public class Path
{
    private readonly IEnvironment _environment;
    private readonly int _length;

    public Path(IEnvironment environment, int length)
    {
        _environment = environment;
        _length = length;
    }

    public TraversalResult TraversePath(IShip ship)
    {
        return _environment.TraverseEnvironment(ship, _length);
    }
}
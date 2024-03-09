using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Router;

public class Route
{
    private readonly List<Path> _paths;

    public Route(IEnumerable<Path> paths)
    {
        _paths = paths.ToList();
    }

    public TraversalResult Traverse(IShip ship)
    {
        int time = 0;
        double fuel = 0;

        foreach (TraversalResult result in _paths.Select(path => path.Environment.TraverseEnvironment(ship)))
        {
            if (result is not TraversalResult.Success success)
                return result;
            time += success.Time;
            fuel += success.Fuel;
        }

        return new TraversalResult.Success(time, fuel);
    }
}
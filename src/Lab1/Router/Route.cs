using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines;

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
        List<Fuel> fuels = new();

        foreach (TraversalResult result in _paths.Select(path => path.TraversePath(ship)))
        {
            if (result is not TraversalResult.Success success)
                return result;
            time += success.Time;
            fuels.AddRange(success.Fuel);
        }

        return new TraversalResult.Success(time, fuels);
    }
}
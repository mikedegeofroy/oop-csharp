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

    public TraversalOutcome Traverse(IShip ship)
    {
        foreach (Path x in _paths)
        {
            ship.TakeDamage(x.Length);
        }

        return new TraversalOutcome.DeathOfCrew();
    }
}
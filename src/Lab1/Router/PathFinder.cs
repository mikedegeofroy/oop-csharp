using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Router.Strategies;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Router;

// This class should calculate all the traversal results, and pass them on to the strategy to decide what ship is best for the task.
public class PathFinder
{
    private readonly IPathFindingStrategy _strategy;

    public PathFinder(IPathFindingStrategy strategy)
    {
        _strategy = strategy;
    }

    public PathFinderResult SelectShip(Route route, IEnumerable<IShip> ships)
    {
        throw new System.NotImplementedException();
    }
}
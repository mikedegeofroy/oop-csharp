using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Router;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Strategies;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

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
        List<Tuple<IShip, TraversalResult>> results = new();

        results.AddRange(ships.Select(ship => new Tuple<IShip, TraversalResult>(ship, route.Traverse(ship))));

        return _strategy.GetBestShip(results);
    }
}
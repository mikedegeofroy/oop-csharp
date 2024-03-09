using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Router;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Strategies;

public interface IPathFindingStrategy
{
    PathFinderResult GetBestShip(IEnumerable<Tuple<IShip, TraversalResult>> results);
}
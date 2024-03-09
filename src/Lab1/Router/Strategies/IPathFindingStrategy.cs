using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Router.Strategies;

public interface IPathFindingStrategy
{
    PathFinderResult GetBestShip(IEnumerable<IShip> ships);
}
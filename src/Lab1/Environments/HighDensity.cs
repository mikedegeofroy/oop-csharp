using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Router;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class HighDensity : IEnvironment
{
    private readonly List<IHighDensityObstacle> _obstacles;

    public HighDensity(IEnumerable<IHighDensityObstacle> obstacles)
    {
        _obstacles = obstacles.ToList();
    }

    public TraversalResult TraverseEnvironment(IShip ship)
    {
        if (ship.JumpEngine == null)
            return new TraversalResult.LostShip("Ship lost in a channel");

        foreach (IHighDensityObstacle highDensityObstacle in _obstacles)
        {
            highDensityObstacle.GiveDamage(ship);
        }

        return new TraversalResult.Success(0, 0);
    }

    public IEnumerable<IObstacle> GetObstacles()
    {
        throw new System.NotImplementedException();
    }
}
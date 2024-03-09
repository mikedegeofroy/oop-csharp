using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Router;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class Cosmos : IEnvironment
{
    private readonly List<ICosmosObstacle> _obstacles;

    public Cosmos(IEnumerable<ICosmosObstacle> obstacles)
    {
        _obstacles = obstacles.ToList();
    }

    public TraversalResult TraverseEnvironment(IShip ship)
    {
        foreach (ICosmosObstacle highDensityObstacle in _obstacles)
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
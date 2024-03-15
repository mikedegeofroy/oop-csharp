using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Router;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class Cosmos : IEnvironment
{
    private readonly List<ICosmosObstacle> _obstacles;

    public Cosmos(IEnumerable<ICosmosObstacle> obstacles)
    {
        _obstacles = obstacles.ToList();
    }

    public Cosmos()
        : this(Enumerable.Empty<ICosmosObstacle>())
    {
    }

    public TraversalResult TraverseEnvironment(IShip ship, int length)
    {
        foreach (ICosmosObstacle highDensityObstacle in _obstacles)
        {
            highDensityObstacle.GiveDamage(ship);
        }

        EngineConsumption consumption = ship.DriveEngine.GetConsumption(length);
        return new TraversalResult.Success(consumption.Time, new[] { consumption.Consumption });
    }

    public void AddObstacle(IObstacle obstacle)
    {
        if (obstacle is not ICosmosObstacle cosmosObstacle)
            throw new ArgumentException("You can't add this obstacle to this environment.");
        _obstacles.Add(cosmosObstacle);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Router;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class HighDensity : IEnvironment
{
    private readonly List<IHighDensityObstacle> _obstacles;

    public HighDensity(IEnumerable<IHighDensityObstacle> obstacles)
    {
        _obstacles = obstacles.ToList();
    }

    public HighDensity()
        : this(Enumerable.Empty<IHighDensityObstacle>())
    {
    }

    public TraversalResult TraverseEnvironment(IShip ship, int length)
    {
        if (ship.JumpEngine == null || ship.JumpEngine.GetRange() < length)
            return new TraversalResult.LostShip("Ship lost in a channel");

        foreach (IHighDensityObstacle highDensityObstacle in _obstacles)
        {
            highDensityObstacle.GiveDamage(ship);
        }

        EngineConsumption consumption = ship.JumpEngine.GetConsumption(length);
        return new TraversalResult.Success(consumption.Time, new[] { consumption.Consumption });
    }

    public void AddObstacle(IObstacle obstacle)
    {
        if (obstacle is not IHighDensityObstacle highDensityObstacle)
            throw new ArgumentException("You can't add this obstacle to this environment.");
        _obstacles.Add(highDensityObstacle);
    }
}
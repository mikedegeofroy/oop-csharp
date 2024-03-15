using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Router;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.DriveEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class NitrineNebula : IEnvironment
{
    private readonly List<INitrineParticleObstacle> _obstacles;

    public NitrineNebula(IEnumerable<INitrineParticleObstacle> obstacles)
    {
        _obstacles = obstacles.ToList();
    }

    public NitrineNebula()
        : this(Enumerable.Empty<INitrineParticleObstacle>())
    {
    }

    public TraversalResult TraverseEnvironment(IShip ship, int length)
    {
        if (ship.DriveEngine is not ExponentialDriveEngine)
            return new TraversalResult.LostShip("The engines weren't powerful enough.");

        foreach (INitrineParticleObstacle x in _obstacles)
        {
            x.GiveDamage(ship);
        }

        EngineConsumption consumption = ship.DriveEngine.GetConsumption(length);
        return new TraversalResult.Success(consumption.Time, new[] { consumption.Consumption });
    }

    public void AddObstacle(IObstacle obstacle)
    {
        if (obstacle is not INitrineParticleObstacle nitrineParticleObstacle)
            throw new ArgumentException("You can't add this obstacle to this environment.");
        _obstacles.Add(nitrineParticleObstacle);
    }
}
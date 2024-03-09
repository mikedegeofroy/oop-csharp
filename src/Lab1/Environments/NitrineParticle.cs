using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Router;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class NitrineParticle : IEnvironment
{
    private readonly List<INitrineParticleObstacle> _obstacles;

    public NitrineParticle(IEnumerable<INitrineParticleObstacle> obstacles)
    {
        _obstacles = obstacles.ToList();
    }

    public TraversalResult TraverseEnvironment(IShip ship)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<IObstacle> GetObstacles()
    {
        throw new System.NotImplementedException();
    }
}
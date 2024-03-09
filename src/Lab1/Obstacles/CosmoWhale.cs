using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class CosmoWhale : INitrineParticleObstacle
{
    private const double Damage = 200;
    private readonly int _population;

    public CosmoWhale(int population)
    {
        _population = population;
    }

    public void GiveDamage(IShip ship)
    {
        ship.TakeDamage(Damage * _population);
    }
}
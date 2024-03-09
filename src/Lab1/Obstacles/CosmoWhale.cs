using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class CosmoWhale : INitrineParticleObstacle
{
    private const double Damage = 200;

    public void GiveDamage(IShip ship)
    {
        ship.TakeDamage(Damage);
    }
}
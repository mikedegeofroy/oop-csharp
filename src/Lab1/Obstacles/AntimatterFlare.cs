using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class AntimatterFlare : IHighDensityObstacle
{
    private const double Damage = 10;

    public void GiveDamage(IShip ship)
    {
        ship.TakeDamage(Damage);
    }
}
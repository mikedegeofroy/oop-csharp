using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Interfaces;

public interface IObstacle
{
    void GiveDamage(IShip ship);
}
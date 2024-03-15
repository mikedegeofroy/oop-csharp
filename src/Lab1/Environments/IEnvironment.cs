using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Router;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public interface IEnvironment
{
    void AddObstacle(IObstacle obstacle);

    TraversalResult TraverseEnvironment(IShip ship, int length);
}
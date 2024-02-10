using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public interface IEnvironment
{
    IEnumerable<IObstacle> GetObstacles();
}
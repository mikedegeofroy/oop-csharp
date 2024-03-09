using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Router;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.ConcreteShips;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShipsAndRoutesTest
{
    [Fact]
    public void Ships_Should_Fail_WhenCantTraverseEnvironment()
    {
        // Arrange
        var shuttle = new PleasureShuttle();
        var path = new Path(new HighDensity(), 100);

        // Act
        TraversalResult result = path.TraversePath(shuttle);

        // Assert
        Assert.IsType<TraversalResult.LostShip>(result);
    }

    [Fact]
    public void Ships2_Should_Fail_WhenCantTraverseEnvironment()
    {
        // Arrange
        var shuttle = new Avgur();
        var path = new Path(new HighDensity(), 100);

        // Act
        TraversalResult result = path.TraversePath(shuttle);

        // Assert
        Assert.IsType<TraversalResult.LostShip>(result);
    }

    [Fact]
    public void Ships2_Should_Fail_WhenNoFlareProtection()
    {
        // Arrange
        var shuttle = new Vaklass();

        var obstacles = new List<IHighDensityObstacle>()
        {
            new AntimatterFlare(),
        };

        var path = new Path(new HighDensity(obstacles), 10);

        // Act
        TraversalResult result = path.TraversePath(shuttle);

        // Assert
        Assert.IsType<TraversalResult.DeathOfCrew>(result);
    }
}
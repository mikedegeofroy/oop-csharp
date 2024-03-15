using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Router;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShipsAndRoutesTest
{
    [Theory]
    [InlineData("Avgur")]
    [InlineData("PleasureShuttle")]
    public void Ships_Should_Fail_WhenCantTraverseEnvironment(string name)
    {
        // Arrange
        IShip shuttle = ShipRepository.CreateShip(name);
        var path = new Path(new HighDensity(), 100);

        // Act
        TraversalResult result = path.TraversePath(shuttle);

        // Assert
        Assert.IsType<TraversalResult.LostShip>(result);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Ships_Should_Fail_WhenNoFlareProtection(bool antiNitrineEmitter)
    {
        // Arrange
        IShip shuttle = ShipRepository.CreateShip("Vaklass", false, antiNitrineEmitter);

        var obstacles = new List<IHighDensityObstacle>()
        {
            new AntimatterFlare(),
        };

        var path = new Path(new HighDensity(obstacles), 10);

        // Act
        TraversalResult result = path.TraversePath(shuttle);

        // Assert
        if (antiNitrineEmitter)
        {
            Assert.IsType<TraversalResult.Success>(result);
        }
        else
        {
            Assert.IsType<TraversalResult.DeathOfCrew>(result);
        }
    }
}
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Router;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Strategies;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.ConcreteShips;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class PathFinderTests
{
    [Fact]
    public void Shuttle_IsPicked_WhenPricesArePriority()
    {
        // Arrange
        var shuttle = new PleasureShuttle();
        var vaklass = new Vaklass();

        var pathFinder = new PathFinder(new BestPriceStrategy());

        var route = new Route(new List<Path>()
        {
            new Path(new Cosmos(), 10),
        });

        // Act
        PathFinderResult result = pathFinder.SelectShip(route, new List<IShip>()
        {
            shuttle,
            vaklass,
        });

        // Assert
        PathFinderResult.Success success = Assert.IsType<PathFinderResult.Success>(result);
        Assert.IsType<PleasureShuttle>(success.Ship);
    }

    [Fact]
    public void Stella_IsPicked_WhenAvgurCantTraverse()
    {
        // Arrange
        var stella = new Stella();
        var avgur = new Avgur();

        var pathFinder = new PathFinder(new BestPriceStrategy());

        var route = new Route(new List<Path>()
        {
            new Path(new HighDensity(), 100),
        });

        // Act
        PathFinderResult result = pathFinder.SelectShip(route, new List<IShip>()
        {
            stella,
            avgur,
        });

        // Assert
        PathFinderResult.Success success = Assert.IsType<PathFinderResult.Success>(result);
        Assert.IsType<Stella>(success.Ship);
    }

    [Fact]
    public void Vaklass_IsPicked_InNitrineNebula()
    {
        // Arrange
        var shuttle = new PleasureShuttle();
        var vaklass = new Vaklass();

        var pathFinder = new PathFinder(new BestPriceStrategy());

        var route = new Route(new List<Path>()
        {
            new Path(new NitrineNebula(), 100),
        });

        // Act
        PathFinderResult result = pathFinder.SelectShip(route, new List<IShip>()
        {
            shuttle,
            vaklass,
        });

        // Assert
        PathFinderResult.Success success = Assert.IsType<PathFinderResult.Success>(result);
        Assert.IsType<Vaklass>(success.Ship);
    }

    [Fact]
    public void Avgur_IsPicked_WhenDealingWithObstacles()
    {
        // Arrange
        var shuttle = new PleasureShuttle();
        var vaklass = new Vaklass();

        var pathFinder = new PathFinder(new BestPriceStrategy());

        var route = new Route(new List<Path>()
        {
            new(new NitrineNebula(), 10),
        });

        // Act
        PathFinderResult result = pathFinder.SelectShip(route, new List<IShip>()
        {
            shuttle,
            vaklass,
        });

        // Assert
        PathFinderResult.Success success = Assert.IsType<PathFinderResult.Success>(result);
        Assert.IsType<Vaklass>(success.Ship);
    }
}
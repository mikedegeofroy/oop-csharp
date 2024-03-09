using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Router;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Strategies;

public class BestPriceStrategy : IPathFindingStrategy
{
    public PathFinderResult GetBestShip(IEnumerable<Tuple<IShip, TraversalResult>> results)
    {
        var possibleChoice = new List<Tuple<IShip, double>>();

        foreach (Tuple<IShip, TraversalResult> result in results)
        {
            if (result.Item2 is not TraversalResult.Success success)
                continue;

            double price = success.Fuel.Sum(FuelExchange.GetFuelPrice);
            IShip ship = result.Item1;

            possibleChoice.Add(new Tuple<IShip, double>(ship, price));
        }

        Tuple<IShip, double>? bestChoice = possibleChoice.MinBy(t => t.Item2);

        if (bestChoice is null)
            return new PathFinderResult.Failed();
        return new PathFinderResult.Success(bestChoice.Item1);
    }
}
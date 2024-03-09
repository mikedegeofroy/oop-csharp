using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Router;

public abstract record TraversalResult
{
    public record Success(int Time, IEnumerable<Fuel> Fuel) : TraversalResult;

    public record LostShip(string Reason) : TraversalResult;

    public record DeathOfCrew : TraversalResult;

    public record DestroyedShip : TraversalResult;
}
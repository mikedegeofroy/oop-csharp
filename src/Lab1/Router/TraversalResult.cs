namespace Itmo.ObjectOrientedProgramming.Lab1.Router;

public abstract record TraversalResult
{
    public record Success(int Time, double Fuel) : TraversalResult;

    public record LostShip(string Reason) : TraversalResult;

    public record DeathOfCrew : TraversalResult;

    public record DestroyedShip : TraversalResult;
}
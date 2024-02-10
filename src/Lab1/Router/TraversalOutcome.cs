namespace Itmo.ObjectOrientedProgramming.Lab1.Router;

public abstract record TraversalOutcome
{
    public record Success(int Time, double Fuel) : TraversalOutcome;

    public record LostShip(string Reason) : TraversalOutcome;

    public record DeathOfCrew : TraversalOutcome;

    public record DestroyedShip : TraversalOutcome;
}
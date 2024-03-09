namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.JumpEngines;

public class AlphaJumpEngine : IJumpEngine
{
    public EngineConsumption GetConsumption(int distance)
    {
        return new EngineConsumption(distance, new Fuel.GravitonMatterFuel(distance));
    }

    public int GetRange()
    {
        return 80;
    }
}
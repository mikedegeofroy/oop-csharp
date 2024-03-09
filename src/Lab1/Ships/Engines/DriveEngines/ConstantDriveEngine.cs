namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.DriveEngines;

public class ConstantDriveEngine : IDriveEngine
{
    public EngineConsumption GetConsumption(int distance)
    {
        return new EngineConsumption(distance, new Fuel.ActivePlasmaFuel(20));
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.DriveEngines;

public class ConstantDriveEngine : IDriveEngine
{
    public EngineConsumption GetConsumption(int distance)
    {
        return new EngineConsumption(distance, distance);
    }
}
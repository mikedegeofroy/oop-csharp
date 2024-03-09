namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines;

public interface IEngine
{
    EngineConsumption GetConsumption(int distance);
}
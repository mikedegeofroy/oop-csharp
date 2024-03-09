using Itmo.ObjectOrientedProgramming.Lab1.Ships.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.DriveEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.ConcreteShips;

public class Meridian : IShip
{
    private readonly IDamagable _hull;

    public Meridian()
    {
        _hull = new DeflectorClass2(new HullClass2());
        DriveEngine = new ExponentialDriveEngine();
        JumpEngine = null;
    }

    public IDriveEngine DriveEngine { get; }
    public IJumpEngine? JumpEngine { get; }

    public void TakeDamage(double points)
    {
        _hull.TakeDamage(points);
    }
}
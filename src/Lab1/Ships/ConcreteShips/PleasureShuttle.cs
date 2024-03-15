using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.DriveEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.ConcreteShips;

public class PleasureShuttle : IShip
{
    private readonly IDamagable _hull;

    public PleasureShuttle(bool photonDeflector = false, bool antiNitrineEmitter = false)
    {
        PhotonDeflector = photonDeflector;
        AntiNitrineEmitter = antiNitrineEmitter;
        _hull = new HullClass1();
        DriveEngine = new ConstantDriveEngine();
        JumpEngine = null;
    }

    public bool PhotonDeflector { get; }
    public bool AntiNitrineEmitter { get; }
    public IDriveEngine DriveEngine { get; }
    public IJumpEngine? JumpEngine { get; }

    public void TakeDamage(double points)
    {
        _hull.TakeDamage(points);
    }
}
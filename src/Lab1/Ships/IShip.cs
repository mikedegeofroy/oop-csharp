using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.DriveEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.JumpEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public interface IShip
{
    bool PhotonDeflector { get;  }
    bool AntiNitrineEmitter { get;  }

    IDriveEngine DriveEngine { get; }
    IJumpEngine? JumpEngine { get; }
    void TakeDamage(double points);
}
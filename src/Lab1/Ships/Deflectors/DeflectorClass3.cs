namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Deflectors;

public class DeflectorClass3 : IDamagable
{
    private readonly IDamagable _damagable;
    private double _hp = 600;

    public DeflectorClass3(IDamagable damagable)
    {
        _damagable = damagable;
    }

    public double TakeDamage(double points)
    {
        double diff = _hp - points;
        _hp -= points;

        return diff > 0 ? _damagable.TakeDamage(diff) : _damagable.TakeDamage(0);
    }
}
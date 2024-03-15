namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Hull;

public class HullClass2 : IDamagable
{
    private double _hp = 200;

    public double TakeDamage(double points)
    {
        double diff = _hp - points;
        _hp -= points;

        if (diff > 0)
            return 0;
        return diff;
    }
}
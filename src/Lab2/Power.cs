using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Power
{
    public Power(int consumption, int provision = 0)
    {
        Consumption = consumption;
        Provision = provision;
    }

    public Power(IList<Power> powers)
    {
        Consumption = powers.Sum(p => p.Consumption);
        Provision = powers.Sum(p => p.Provision);
    }

    public int Consumption { get; }
    public int Provision { get; }
}
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Filter;

public interface IFilter
{
    public bool Filter(IMessage message);
}
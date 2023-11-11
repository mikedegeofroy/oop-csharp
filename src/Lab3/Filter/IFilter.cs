using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Filter;

public interface IFilter
{
    bool Filter(IMessage message);
}
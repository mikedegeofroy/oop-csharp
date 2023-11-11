using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Filter;

// TODO
// fix this shit, make priorities a number
public class PriorityFilter : IFilter
{
    private int _priorityFilter;

    public PriorityFilter(int priorityLevel = 0)
    {
        _priorityFilter = priorityLevel;
    }

    public void SetFilter(int priorityLevel)
    {
        _priorityFilter = priorityLevel;
    }

    public bool Filter(IMessage message)
    {
        return message.Priority >= _priorityFilter;
    }
}
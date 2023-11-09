using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Filter;

public class PriorityFilter : IFilter
{
    private IEnumerable<Priority> _filter;

    public PriorityFilter()
    {
        _filter = new List<Priority>()
        {
            Priority.High,
            Priority.Medium,
            Priority.Low,
        };
    }

    public void SetFilter(params Priority[] filter)
    {
        _filter = new List<Priority>(filter);
    }

    public bool Filter(IMessage message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        return _filter.Contains(message.Priority);
    }
}
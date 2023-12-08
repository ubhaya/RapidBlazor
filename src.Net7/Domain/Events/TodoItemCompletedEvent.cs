using RapidBlazor.Old.Domain.Common;
using RapidBlazor.Old.Domain.Entities;

namespace RapidBlazor.Old.Domain.Events;

public class TodoItemCompletedEvent : BaseEvent
{
    public TodoItemCompletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}

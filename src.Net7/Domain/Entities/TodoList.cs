using RapidBlazor.Old.Domain.Common;

namespace RapidBlazor.Old.Domain.Entities;

public class TodoList : BaseAuditableEntity
{
    public string Title { get; set; } = string.Empty;

    public string Colour { get; set; } = string.Empty;

    public ICollection<TodoItem> Items { get; set; }
        = new List<TodoItem>();
}

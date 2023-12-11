namespace RapidBlazor.WebUi.Shared.TodoItems;

public class CreateTodoItemRequest
{
    public int ListId { get; set; }
    public string Title { get; set; } = string.Empty;
}

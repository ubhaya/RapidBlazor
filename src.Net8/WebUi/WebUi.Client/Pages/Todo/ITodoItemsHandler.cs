using RapidBlazor.WebUi.Shared.TodoItems;

namespace RapidBlazor.WebUi.Client.Pages.Todo;

public interface ITodoItemsHandler
{
    Task PutTodoItemAsync(int id, UpdateTodoItemRequest request);
    Task<int> PostTodoItemAsync(CreateTodoItemRequest request);
    Task DeleteTodoItemAsync(int id);
}

using RapidBlazor.WebUi.Shared.TodoLists;

namespace RapidBlazor.WebUi.Client.Pages.Todo;

public interface ITodoListHandler
{
    Task<TodosVm> GetTodoListsAsync();
    Task PutTodoListAsync(int id, UpdateTodoListRequest request);
    Task DeleteTodoListAsync(int id);
    Task<int> PostTodoListAsync(CreateTodoListRequest request);
}

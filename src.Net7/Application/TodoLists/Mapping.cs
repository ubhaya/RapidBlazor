using RapidBlazor.Old.Domain.Entities;
using RapidBlazor.Old.WebUI.Shared.TodoLists;

namespace RapidBlazor.Old.Application.TodoLists;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<TodoList, TodoListDto>();
        CreateMap<TodoItem, TodoItemDto>();
    }
}

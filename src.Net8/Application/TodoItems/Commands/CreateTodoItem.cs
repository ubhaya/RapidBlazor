using RapidBlazor.WebUi.Shared.TodoItems;

namespace RapidBlazor.Application.TodoItems.Commands;

public record CreateTodoItemCommand(CreateTodoItemRequest Item) : IRequest<int>;

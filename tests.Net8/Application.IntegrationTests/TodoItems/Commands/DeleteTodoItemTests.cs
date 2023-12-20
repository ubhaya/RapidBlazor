using Ardalis.GuardClauses;
using RapidBlazor.Application.TodoItems.Commands;
using RapidBlazor.Application.TodoLists.Commands;
using RapidBlazor.Domain.Entities;
using RapidBlazor.WebUi.Shared.TodoItems;
using RapidBlazor.WebUi.Shared.TodoLists;

namespace RapidBlazor.Application.IntegrationTests.TodoItems.Commands;

public class DeleteTodoItemTests : Testing
{
    [Fact]
    public async Task ShouldRequiredValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);
        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand(
            new CreateTodoListRequest { Title = "New List" }));

        var itemId = await SendAsync(new CreateTodoItemCommand(
            new CreateTodoItemRequest { ListId = listId, Title = "Tasks" }));

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}

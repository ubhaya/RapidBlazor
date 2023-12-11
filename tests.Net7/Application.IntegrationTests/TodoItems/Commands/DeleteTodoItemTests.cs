﻿using Ardalis.GuardClauses;
using RapidBlazor.Old.Application.TodoItems.Commands;
using RapidBlazor.Old.Application.TodoLists.Commands;
using RapidBlazor.Old.Domain.Entities;
using RapidBlazor.Old.WebUI.Shared.TodoItems;
using RapidBlazor.Old.WebUI.Shared.TodoLists;

namespace RapidBlazor.Old.Application.IntegrationTests.TodoItems.Commands;

using static Testing;

public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand(
            new CreateTodoListRequest
            {
                Title = "New List"
            }));

        var itemId = await SendAsync(new CreateTodoItemCommand(
            new CreateTodoItemRequest
            {
                ListId = listId,
                Title = "Tasks"
            }));

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
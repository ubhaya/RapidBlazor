using MediatR;
using RapidBlazor.Application.Users.Queries;
using RapidBlazor.WebUi.Client.Pages.Admin.Users;
using RapidBlazor.WebUi.Client.Pages.Todo;
using RapidBlazor.WebUi.Shared.Authorization;

namespace RapidBlazor.WebUi.Services;

public static class AppService
{
    public static WebApplicationBuilder AddApplicationServerServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserHandler, UserServerHandler>();
        builder.Services.AddScoped<ITodoListHandler, TodoListServerHandler>();
        builder.Services.AddScoped<ITodoItemsHandler, TodoItemsServerHandler>();
        
        return builder;
    }
}

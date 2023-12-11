

using RapidBlazor.Application.Common.Behaviours;
using RapidBlazor.Application.TodoItems.Commands;
using RapidBlazor.WebUi.Shared.TodoLists;
using System.Reflection;
using FluentValidation;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateTodoListRequestValidator>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblyContaining<CreateTodoItemCommand>();
        });

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}

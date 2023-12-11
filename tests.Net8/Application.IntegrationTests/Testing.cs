using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RapidBlazor.WebUi.Data;
using Respawn;
using Respawn.Graph;

namespace RapidBlazor.Application.IntegrationTests;

public class Testing : IAsyncLifetime
{
    private static WebApplicationFactory<Program> _factory = default!;
    private static IConfiguration _configuration = default!;
    private static IServiceScopeFactory _scopeFactory = default!;
    private static Respawner _respawner = default!;
    private static string? _currentUserId;
    private static string? _connectionString;

    public async Task InitializeAsync()
    {
        _factory = new CustomWebApplicationFactory();
        _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        _configuration = _factory.Services.GetRequiredService<IConfiguration>();
        _connectionString = _configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(_connectionString);

        _respawner = await Respawner.CreateAsync(_connectionString,
            new RespawnerOptions { TablesToIgnore = new[] { new Table("__EFMigrationsHistory") }, });
        await _respawner.ResetAsync(_connectionString);
    }

    public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        using var scope = _scopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        return await mediator.Send(request);
    }

    public static string? GetCurrentUserId()
    {
        return _currentUserId;
    }

    public static Task<string> RunAsDefaultUserAsync()
    {
        return RunAsUserAsync("test@local", "Testing1234!", Array.Empty<string>());
    }

    public static Task<string> RunAsAdministratorAsync()
    {
        return RunAsUserAsync("administrator@local", "Administrator1234!", new[] { "Administrator" });
    }

    public async static Task ResetState()
    {
        await _respawner.ResetAsync(_connectionString!);

        _currentUserId = null;
    }

    public ValueTask<TEntity?> FindAsync<TEntity>(params object[] keyValues) where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        return context.FindAsync<TEntity>(keyValues);
    }
    
    public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Add(entity);

        await context.SaveChangesAsync();
    }

    public Task<int> CountAsync<TEntity>() where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        return context.Set<TEntity>().CountAsync();
    }

    private static async Task<string> RunAsUserAsync(string userName, string password, string[] roles)
    {
        using var scope = _scopeFactory.CreateScope();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        var user = new ApplicationUser { UserName = userName, Email = userName };
        var result = await userManager.CreateAsync(user, password);

        if (roles.Any())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (string role in roles)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }

            await userManager.AddToRolesAsync(user, roles);
        }

        if (result.Succeeded)
        {
            _currentUserId = user.Id;
            return _currentUserId;
        }

        var errors = string.Join(Environment.NewLine, result.Errors.Select(e => e.Description));
        throw new Exception($"Unable to create {userName}.{Environment.NewLine}{errors}");
    }

    public Task DisposeAsync()
    {
        throw new NotImplementedException();
    }
}

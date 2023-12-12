using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace RapidBlazor.WebUi.Client.Pages.Admin.Users;

public static class AppServices
{
    public static WebAssemblyHostBuilder AddApplicationWebAssemblyServices(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddHttpClient("RapidBlazor.WebUi", client =>
            client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
        
        builder.Services.AddScoped(sp => 
            sp.GetRequiredService<IHttpClientFactory>().CreateClient("RapidBlazor.WebUi"));

        builder.Services.Scan(scan => scan
            .FromAssemblyOf<ITodoListsClient>()
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return builder;
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace RapidBlazor.Application.IntegrationTests;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection Remove<TService>(this IServiceCollection serviceCollection)
    {
        var serviceDescriptor = serviceCollection.FirstOrDefault(d =>
            d.ServiceType == typeof(TService));

        if (serviceDescriptor is not null)
        {
            serviceCollection.Remove(serviceDescriptor);
        }

        return serviceCollection;
    }
}

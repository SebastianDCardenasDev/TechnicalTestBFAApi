using ExternalServices.Adapters.RegionApi;
using Microsoft.Extensions.DependencyInjection;

namespace ExternalServices
{
    public static class AdaptersConfiguration
    {
        public static IServiceCollection AddResourcesApiConnection(this IServiceCollection services, string? urlApi)
        {
            if (string.IsNullOrWhiteSpace(urlApi))
                throw new ArgumentException("La URL de la API no puede ser vacía", nameof(urlApi));

            services.AddHttpClient<IRegionApiService, RegionApiService>(client =>
            {
                client.BaseAddress = new Uri(urlApi);
                client.Timeout = TimeSpan.FromSeconds(30);
            });

            return services;
        }
    }
}

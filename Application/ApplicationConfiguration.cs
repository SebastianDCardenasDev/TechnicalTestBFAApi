using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IRegionService, RegionService>();

            return services;
        }
    }
}

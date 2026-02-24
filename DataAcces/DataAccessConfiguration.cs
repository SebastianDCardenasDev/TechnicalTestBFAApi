using Application.Services;
using DataAcces.Configurations;
using DataAcces.Persistences;
using DataAcces.Persistences.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAcces
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection AddDataAccessConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string database = DatabaseResource.ConnectionString!;

            services.AddDbContext<DataBaseContext>(contextOptions =>
                contextOptions.UseSqlServer(database), ServiceLifetime.Scoped);

            services.AddScoped<IRegionRepository, RegionRepository>();

            return services;
        }

        public static IServiceCollection AddDataAccessConnection(this IServiceCollection services, string? environment)
        {
            if (string.IsNullOrEmpty(DatabaseResource.ConnectionString))
                DatabaseResource.ConnectionString = environment;

            return services;
        }
    }
}

using StoreService.Persistence;
using Microsoft.EntityFrameworkCore;

namespace StoreService.Api.Extensions.DependencyInjection
{
    public static class DatabaseInjection
    {
        public static IServiceCollection AddConfiguredDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Data Context
            var db = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(db));

            return services;
        }
    }
}
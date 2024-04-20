using StoreService.Application.Interfaces;
using StoreService.Persistence;

namespace StoreService.Api.Extensions.DependencyInjection
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
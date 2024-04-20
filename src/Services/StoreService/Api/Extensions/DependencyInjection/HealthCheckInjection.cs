using Communal.Api.HealthChecks;

namespace StoreService.Api.Extensions.DependencyInjection
{
    public static class HealthCheckInjection
    {
        public static IServiceCollection AddConfiguredHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<GeneralHealthCheck>("User-check");

            return services;
        }
    }
}
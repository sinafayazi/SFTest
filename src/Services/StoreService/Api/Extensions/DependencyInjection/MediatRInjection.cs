using System.Reflection;
using Communal.Application.Infrastructure.Operations;
using StoreService.Application.Behaviors.Common;
using MediatR;
using StoreService.Application.Behaviors.Products;
using StoreService.Application.Models.Commands.Products;

namespace StoreService.Api.Extensions.DependencyInjection
{
    public static class MediatRInjection
    {
        public static IServiceCollection AddConfiguredMediatR(this IServiceCollection services)
        {
            // Handlers
            services.AddMediatR(typeof(AddProductCommand).GetTypeInfo().Assembly);

            // Generic behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommitBehavior<,>));

            // Validation behaviors
            services.AddTransient(typeof(IPipelineBehavior<AddProductCommand, OperationResult>),
                typeof(AddProductValidationBehavior<AddProductCommand, OperationResult>));
           
            return services;
        }
    }
}
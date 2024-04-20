using Communal.Application.Infrastructure.Operations;
using MediatR;
using StoreService.Application.Helpers;
using StoreService.Application.Models.Commands.Products;
using StoreService.Application.Validators.Products;

namespace StoreService.Application.Behaviors.Products
{
    public class AddProductValidationBehavior<TRequest, TResponse> : IPipelineBehavior<AddProductCommand, OperationResult>
    {
        public async Task<OperationResult> Handle(AddProductCommand request,
            CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
        {
            // Validation
            var validator = new AddProductCommandValidator();
            var validation = validator.Validate(request);
            
            if (!validation.IsValid)
                return new OperationResult(OperationResultStatus.InvalidRequest, validation.GetFirstErrorMessage());
            
           return await next();
        }
    }
}
using Communal.Application.Infrastructure.Operations;
using MediatR;
using StoreService.Application.Errors;
using StoreService.Application.Helpers;
using StoreService.Application.Interfaces;
using StoreService.Application.Models.Commands.Products;
using StoreService.Application.Specifications.Products;

namespace StoreService.Application.Handlers.Products
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            // Checking duplicate
            var isExist = await _unitOfWork.Products
                .ExistsAsync(new DuplicateProductSpecification(request.Title).ToExpression());
            if (isExist)
                return new OperationResult(OperationResultStatus.Unprocessable, value: ProductErrors.DuplicateTitleError);
            
           
            // Factory
            var entity = ProductHelper.CreateProduct(request);

            _unitOfWork.Products.Add(entity);

            return new OperationResult(OperationResultStatus.Created, value: entity, isPersistable: true);
        }
    }
}
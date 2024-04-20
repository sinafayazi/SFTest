using Communal.Application.Constants;
using Communal.Application.Infrastructure.Operations;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using StoreService.Application.Errors;
using StoreService.Application.Interfaces;
using StoreService.Application.Models.Commands.Products;
using StoreService.Domain.Products;

namespace StoreService.Application.Handlers.Products
{
    internal class UpdateIncreaseProductInventoryCountCommandHandler : IRequestHandler<UpdateIncreaseProductInventoryCountCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;


        public UpdateIncreaseProductInventoryCountCommandHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }

        public async Task<OperationResult> Handle(UpdateIncreaseProductInventoryCountCommand request, CancellationToken cancellationToken)
        {
            // Get
            Product product = null;
            if (_memoryCache.TryGetValue(RedisKeys.ProductKey(request.ProductId), out Product prod))
            {
                product = prod;
            }
            else
            {
                product = await _unitOfWork.Products.GetProductByIdAsync(request.ProductId);
                var cachedValue = await _memoryCache.GetOrCreateAsync(
                RedisKeys.ProductKey(request.ProductId),
                cacheEntry =>
                {
                    cacheEntry.SlidingExpiration = TimeSpan.FromSeconds(3);
                    return Task.FromResult(product);
                });
            }

            if (product == null)
            {
                return new OperationResult(OperationResultStatus.Unprocessable, value: ProductErrors.ProductNotFoundError);
            }
            
            // Update
            product.InventoryCount += request.IncreaseAmount;

            _unitOfWork.Products.Update(product);

            return new OperationResult(OperationResultStatus.Ok, value: product, isPersistable: true);
        }
    }
}

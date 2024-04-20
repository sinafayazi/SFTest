using Communal.Application.Constants;
using Communal.Application.Infrastructure.Operations;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using StoreService.Application.Errors;
using StoreService.Application.Interfaces;
using StoreService.Application.Mappers;
using StoreService.Application.Models.Queries.Products;
using StoreService.Domain.Products;

namespace StoreService.Application.Handlers.Products
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;


        public GetProductQueryHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }

        public async Task<OperationResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
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
                return new OperationResult(OperationResultStatus.NotFound, value: ProductErrors.ProductNotFoundError);

            // Map
            var response = product.MapToProductResponse();

            return new OperationResult(OperationResultStatus.Ok, value: response);
        }
    }
}
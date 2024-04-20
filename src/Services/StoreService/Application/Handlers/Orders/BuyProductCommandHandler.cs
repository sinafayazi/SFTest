using Communal.Application.Constants;
using Communal.Application.Infrastructure.Operations;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using StoreService.Application.Errors;
using StoreService.Application.Helpers;
using StoreService.Application.Interfaces;
using StoreService.Application.Models.Commands.Orders;
using StoreService.Domain.Products;
using StoreService.Domain.Users;

namespace StoreService.Application.Handlers.Orders
{
    public class BuyProductCommandHandler : IRequestHandler<BuyProductCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;


        public BuyProductCommandHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }

        public async Task<OperationResult> Handle(BuyProductCommand request, CancellationToken cancellationToken)
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
            
            if (product.InventoryCount == 0)
                return new OperationResult(OperationResultStatus.Unprocessable, value: ProductErrors.ProductOutOfStockError);
            
            User user = null;
            if (_memoryCache.TryGetValue(RedisKeys.UserKey(request.BuyerId), out User userCache ))
            {
                user = userCache;
            }
            else
            {
                user = await _unitOfWork.Users.GetUserByIdAsync(request.BuyerId);
                var cachedValue = await _memoryCache.GetOrCreateAsync(
                    RedisKeys.UserKey(request.BuyerId),
                    cacheEntry =>
                    {
                        cacheEntry.SlidingExpiration = TimeSpan.FromSeconds(3);
                        return Task.FromResult(user);
                    });
            }
            
            if (user == null)
                return new OperationResult(OperationResultStatus.Unprocessable, value: ProductErrors.UserNotFoundError);

            // Factory
            var entity = OrderHelper.CreateOrder(request);
            _unitOfWork.Orders.Add(entity);

            product.InventoryCount--;
            _unitOfWork.Products.Update(product);

            return new OperationResult(OperationResultStatus.Ok, value: product, isPersistable: true);
        }
    }
}

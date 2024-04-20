using StoreService.Application.Models.Commands.Orders;
using StoreService.Domain.Orders;

namespace StoreService.Application.Helpers
{
    public static class OrderHelper
    {
        public static Order CreateOrder(BuyProductCommand command) => new Order()
        {
            BuyerId = command.BuyerId,
            ProductId = command.ProductId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        
      }
}
using StoreService.Domain.Orders;

namespace StoreService.Application.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrderByIdAsync(int id);
    }
}
using Microsoft.EntityFrameworkCore;
using StoreService.Application.Interfaces.Repositories;
using StoreService.Domain.Orders;

namespace StoreService.Persistence.Repositories.Orders
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly IQueryable<Order> _queryable;
        
        public OrderRepository(AppDbContext context) : base(context)
        {
            _queryable = DbContext.Set<Order>();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _queryable.FirstOrDefaultAsync(x => x.Id == id);
        }
        
        
    }
}
using StoreService.Application.Interfaces;
using StoreService.Application.Interfaces.Repositories;
using StoreService.Persistence.Repositories.Orders;
using StoreService.Persistence.Repositories.Products;
using StoreService.Persistence.Repositories.Users;

namespace StoreService.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IProductRepository Products { get; }
        public IUserRepository Users { get; }
        public IOrderRepository Orders { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Products = new ProductRepository(_context);
            Users = new UserRepository(_context);
            Orders = new OrderRepository(_context);
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
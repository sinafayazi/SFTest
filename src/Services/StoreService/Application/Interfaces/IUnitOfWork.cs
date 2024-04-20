using StoreService.Application.Interfaces.Repositories;

namespace StoreService.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        IOrderRepository Orders { get; }

        Task<bool> CommitAsync();
    }
}
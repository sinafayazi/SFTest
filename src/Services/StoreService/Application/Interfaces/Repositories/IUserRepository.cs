using StoreService.Domain.Users;

namespace StoreService.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByIdAsync(int id);
    }
}
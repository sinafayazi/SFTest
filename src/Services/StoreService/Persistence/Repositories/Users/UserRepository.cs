using Microsoft.EntityFrameworkCore;
using StoreService.Application.Interfaces.Repositories;
using StoreService.Domain.Users;

namespace StoreService.Persistence.Repositories.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IQueryable<User> _queryable;

        public UserRepository(AppDbContext context) : base(context)
        {
            _queryable = DbContext.Set<User>();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _queryable.FirstOrDefaultAsync(x => x.Id == id);
        }
        
    }
}
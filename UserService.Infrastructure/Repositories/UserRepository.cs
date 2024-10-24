
using UserService.Domain.Entities;
using UserService.Domain.Repositories;

namespace UserService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public async Task AddAsync(User user) 
        {
            await Task.Run(() => _users.Add(user));
        }

        public async Task<User> GetByIdAsync(Guid id) 
        {
            return await Task.Run(() => _users.Find(e => e.Id == id));
        }
    }
}

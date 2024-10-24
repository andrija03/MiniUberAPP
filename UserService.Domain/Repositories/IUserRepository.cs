
using UserService.Domain.Entities;

namespace UserService.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByIdAsync(Guid id);
    }
}


using UserService.Application.Dtos;

namespace UserService.Application.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> CreateUserAsync(CreateUserDto userDto);

        Task UpdateUserAsync(Guid id, string name, string email);

        Task DeleteUserAsync(Guid id);

    }
}

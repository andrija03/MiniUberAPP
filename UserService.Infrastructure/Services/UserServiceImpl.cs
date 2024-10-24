
using UserService.Application.Dtos;
using UserService.Application.Services;

namespace UserService.Infrastructure.Services
{
    public class UserServiceImpl : IUserService
    {
        private readonly List<UserDto> _users = new List<UserDto>(); 

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
 
            return await Task.FromResult(_users.FirstOrDefault(u => u.Id == id)); 
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {

            return await Task.FromResult(_users); 
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto userDto)
        {
            var newUser = new UserDto
            {
                Id = Guid.NewGuid(), 
                Name = userDto.Name,
                Email = userDto.Email
            };
            _users.Add(newUser); 
            return await Task.FromResult(newUser); 
        }

        public async Task UpdateUserAsync(Guid id, string name, string email)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Name = name;
                user.Email = email;
            }
            await Task.CompletedTask; 
        }
        public async Task DeleteUserAsync(Guid id) 
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            await Task.CompletedTask;
        }
    }
}

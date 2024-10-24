using MediatR;
using UserService.Application.Dtos;

namespace UserService.Application.Commands
{
    public class GetUsersQuery : IRequest<List<UserDto>>
    {
        public string Name { get; set; } 
        public string Email { get; set; } 
    }
}

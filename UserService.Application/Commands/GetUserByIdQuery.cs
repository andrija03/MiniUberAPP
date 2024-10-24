using MediatR;
using UserService.Application.Dtos;

namespace UserService.Application.Commands
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}

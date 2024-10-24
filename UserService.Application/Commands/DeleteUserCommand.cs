using MediatR;

namespace UserService.Application.Commands
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}

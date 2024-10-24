using MediatR;

namespace UserService.Application.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

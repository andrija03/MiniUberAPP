using MediatR;

namespace UserService.Application.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public CreateUserCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}

using MediatR;

namespace DriverService.Application.Commands
{
    public class CreateDriverCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public CreateDriverCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}

using MediatR;
using UserService.Application.Commands;
using UserService.Domain.Entities;
using UserService.Domain.Repositories;

namespace UserService.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email);
            await _repository.AddAsync(user);
            return user.Id;
        }
    }
}

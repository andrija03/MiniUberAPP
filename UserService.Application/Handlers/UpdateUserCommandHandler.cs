using MediatR;
using UserService.Application.Commands;
using UserService.Application.Services;

namespace UserService.Application.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.UpdateUserAsync(request.Id, request.Name, request.Email);
            return Unit.Value;
        }
    }
}

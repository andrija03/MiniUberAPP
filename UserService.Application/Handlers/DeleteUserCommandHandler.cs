using MediatR;
using UserService.Application.Commands;
using UserService.Application.Services;





namespace UserService.Application.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            // Implementacija logike za brisanje korisnika
            await _userService.DeleteUserAsync(request.Id);
            return Unit.Value; // Indikacija uspeha
        }
    }
}

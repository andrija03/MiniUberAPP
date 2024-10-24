using MediatR;
using UserService.Application.Commands;
using UserService.Application.Dtos;
using UserService.Application.Services;


namespace UserService.Application.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserService _userService; 

        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService; 
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByIdAsync(request.Id);
        }
    }
}

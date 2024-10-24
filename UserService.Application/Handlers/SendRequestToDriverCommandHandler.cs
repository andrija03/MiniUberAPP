using MediatR;
using UserService.Application.Commands;
using UserService.Application.Services;

namespace UserService.Application.Handlers
{
    public class SendRequestToDriverCommandHandler : IRequestHandler<SendRequestToDriverCommand, bool>
    {
        private readonly IDriverService _driverService;

        public SendRequestToDriverCommandHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task<bool> Handle(SendRequestToDriverCommand request, CancellationToken cancellationToken)
        {
            var success = await _driverService.SendRequestToDriver(request.DriverId, request.UserId);
            return success;
        }
    }
}

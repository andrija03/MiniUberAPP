using MediatR;

namespace DriverService.Application.Commands
{
    public class RespondToRideRequestCommand : IRequest<bool>
    {
        public Guid DriverId { get; set; }
        public bool IsAccepted { get; set; }
    }
}

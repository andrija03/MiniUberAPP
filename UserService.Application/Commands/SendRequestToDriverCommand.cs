using MediatR;

namespace UserService.Application.Commands
{
    public class SendRequestToDriverCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid DriverId { get; set; }
    }
}

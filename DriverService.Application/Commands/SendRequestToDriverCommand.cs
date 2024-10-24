using MediatR;

namespace DriverService.Application.Commands
{
    public class SendRequestToDriverCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid DriverId { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public int DurationInSeconds { get; set; }
    }
}

using MediatR;


namespace SharedKernel.Commands
{
    public class UpdateRequestCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DriverId { get; set; }
        public string Status { get; set; }
        public DateTime RequestTime { get; set; }
    }
}

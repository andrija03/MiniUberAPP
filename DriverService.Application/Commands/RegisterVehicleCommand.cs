using MediatR;

namespace DriverService.Application.Commands
{
    public class RegisterVehicleCommand : IRequest<Guid>
    {
        public Guid DriverId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int SeatCount { get; set; }

        //public RegisterVehicleCommand() { }
        public RegisterVehicleCommand(Guid driverId, string brand, string model, string color, int seatCount)
        {
            DriverId = driverId;
            Brand = brand;
            Model = model;
            Color = color;
            SeatCount = seatCount;
        }
    }
}

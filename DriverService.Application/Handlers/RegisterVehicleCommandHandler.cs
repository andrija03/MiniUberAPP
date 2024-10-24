using MediatR;
using DriverService.Domain.Entities;
using DriverService.Domain.Repositories;
using DriverService.Application.Commands;


namespace DriverService.Application.Handlers
{
    public class RegisterVehicleCommandHandler : IRequestHandler<RegisterVehicleCommand, Guid>
    {
        private readonly IDriverRepository _driverRepository;

        public RegisterVehicleCommandHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<Guid> Handle(RegisterVehicleCommand request, CancellationToken cancellationToken)
        {

            var driver = await _driverRepository.GetByIdAsync(request.DriverId);
            if (driver == null)
            {
                throw new Exception($"Driver with ID {request.DriverId} not found.");
            }

           
            if (request.SeatCount <= 1)
            {
                throw new ArgumentException("Seat count must be greater than zero.");
            }

            var vehicle = new Vehicle(request.Brand, request.Model, request.Color, request.SeatCount);
            driver.RegisterVehicle(vehicle);

            return vehicle.Id;
        }
    }
}

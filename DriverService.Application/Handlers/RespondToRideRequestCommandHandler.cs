using DriverService.Application.Commands;
using DriverService.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverService.Application.Handlers
{
    public class RespondToRideRequestCommandHandler : IRequestHandler<RespondToRideRequestCommand, bool>
    {
        private readonly IDriverRepository _driverRepository;

        public RespondToRideRequestCommandHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<bool> Handle(RespondToRideRequestCommand request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetByIdAsync(request.DriverId);
            if (driver == null || !driver.IsAvailable)
            {
                throw new Exception("Driver not available");
            }

            if (request.IsAccepted)
            {
                driver.MarkAsBusy();
            }
            else
            {
                driver.MarkAsAvailable();
            }

            await _driverRepository.SaveAsync(driver);
            return request.IsAccepted;
        }
    }
}

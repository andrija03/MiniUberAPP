using DriverService.Application.Queries;
using DriverService.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverService.Application.Handlers
{
    public class GetAvailableDriversQueryHandler : IRequestHandler<GetAvailableDriversQuery, List<DriverDto>>
    {
        private readonly IDriverRepository _driverRepository;

        public GetAvailableDriversQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<List<DriverDto>> Handle(GetAvailableDriversQuery request, CancellationToken cancellationToken)
        {
            var availableDrivers = await _driverRepository.GetAvailableDriversAsync();
            return availableDrivers.Select(d => new DriverDto
            {
                DriverId = d.Id,
                Name = d.Name,
                VehicleModel = d.ActiveVehicle?.Model ?? "No active vehicle" // Proverava da li postoji aktivno vozilo
            }).ToList();
        }
    }
}

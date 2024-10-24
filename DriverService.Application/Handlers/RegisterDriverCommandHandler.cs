using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using DriverService.Domain.Entities;
using DriverService.Domain.Repositories;
using DriverService.Application.Commands;

namespace DriverService.Application.Handlers
{
    public class RegisterDriverCommandHandler : IRequestHandler<RegisterDriverCommand, Guid>
    {
        private readonly IDriverRepository _driverRepository;

        public RegisterDriverCommandHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<Guid> Handle(RegisterDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = new Driver(request.Name, request.LicenseNumber);
            await _driverRepository.AddAsync(driver);
            return driver.Id;
        }
    }
}

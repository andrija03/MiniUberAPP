using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverService.Application.Queries
{
    public class GetAvailableDriversQuery : IRequest<List<DriverDto>> { }

    public class DriverDto
    {
        public Guid DriverId { get; set; }
        public string Name { get; set; }
        public string VehicleModel { get; set; }
    }
}

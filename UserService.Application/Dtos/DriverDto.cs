

namespace UserService.Application.Dtos
{
    public class DriverDto
    {
        public Guid DriverId { get; set; }
        public string Name { get; set; }
        public string VehicleModel { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
    }
}

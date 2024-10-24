using UserService.Application.Dtos; 
using UserService.Application.Services;
using DriverService.Domain.Entities;
using UserService.Domain.Entities;
using SharedKernel;


namespace UserService.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly List<Driver> _drivers;
        private readonly List<User> _users;

        public DriverService()
        {
            _drivers = new List<Driver>
            {
                new Driver("John Doe", "ABC123"),
                new Driver("Jane Smith", "XYZ456"),
            };

            _drivers[0].StartLatitude = 40.7128;
            _drivers[0].StartLongitude = -74.0060;
            _drivers[1].StartLatitude = 34.0522;
            _drivers[1].StartLongitude = -118.2437;

            _users = new List<User>
            {
                 new User("User 1", "user1@example.com"),
                 new User("User 2", "user2@example.com")
            };
        }

        public async Task<bool> SendRequestToDriver(Guid driverId, Guid userId)
        {
            var driver = _drivers.FirstOrDefault(d => d.Id == driverId);
            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (driver == null || !driver.IsAvailable)
            {
                return false; 
            }

            
            driver.MarkAsBusy();
            user.CurrentRide = new Ride(driver.Id, user.Id);

            // Simulacija trajanja voznje
            driver.DurationInSeconds = 120; 
            await Task.Delay(driver.DurationInSeconds * 1000); 

            // Nakon voznnje oslobodi vozana
            driver.MarkAsAvailable();
            driver.DurationInSeconds = 0;

            return true;
        }

        public async Task<List<DriverDto>> GetAvailableDriversAsync()
        {
            var availableDrivers = _drivers
                .Where(d => d.IsAvailable) // Proverava dostupnost vozaca
                .Select(d => new DriverDto
                {
                    DriverId = d.Id,
                    Name = d.Name,
                    VehicleModel = d.ActiveVehicle?.Model, // Ako postoji, dodaj model vozila
                    StartLatitude = d.StartLatitude,
                    StartLongitude = d.StartLongitude
                })
                .ToList();

            return await Task.FromResult(availableDrivers);
        }
    }
}

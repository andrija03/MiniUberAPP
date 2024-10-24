using DriverService.Domain.Repositories;
using DriverService.Domain.Entities;

namespace DriverService.Infrastructure.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly List<Driver> _drivers = new();

        public async Task AddAsync(Driver driver)
        {
            await Task.Run(() => _drivers.Add(driver));
        }

        public async Task<Driver> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _drivers.FirstOrDefault(d => d.Id == id));
        }

        public async Task<List<Driver>> GetAllAsync()
        {
            return await Task.Run(() => _drivers);
        }

        public async Task<List<Driver>> GetAvailableDriversAsync()
        {
            return await Task.Run(() => _drivers.Where(d => d.IsAvailable).ToList());
        }

        public async Task SaveAsync(Driver driver)
        {
            await Task.CompletedTask;
        }
    }
}

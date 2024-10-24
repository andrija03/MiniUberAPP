using DriverService.Domain.Entities;

namespace DriverService.Domain.Repositories
{
    public interface IDriverRepository
    {
        Task AddAsync(Driver driver);
        Task<Driver> GetByIdAsync(Guid id);

        Task<List<Driver>> GetAllAsync();

        Task<List<Driver>> GetAvailableDriversAsync();

        Task SaveAsync(Driver driver);
    }
}

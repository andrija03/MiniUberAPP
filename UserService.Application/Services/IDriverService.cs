
using UserService.Application.Dtos;

namespace UserService.Application.Services
{
    public interface IDriverService
    {
        Task<List<DriverDto>> GetAvailableDriversAsync();
        Task<bool> SendRequestToDriver(Guid driverId, Guid userId);
    }
}

using EmployeeService.Domain.Entities;


namespace EmployeeService.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee);
        Task<Employee> GetByIdAsync(Guid id);
    }
}

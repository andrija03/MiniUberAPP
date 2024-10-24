using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Repositories;

namespace EmployeeService.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly List<Employee> _employees = new();


        public async Task AddAsync(Employee employee)
        {

            await Task.Run(() => _employees.Add(employee));
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _employees.Find(e => e.Id == id));
        }
    }
}


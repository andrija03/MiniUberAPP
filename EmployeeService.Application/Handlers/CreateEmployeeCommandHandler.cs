using EmployeeService.Application.Commands;
using MediatR;
using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Application.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _repository;

        public CreateEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee(request.Name, request.Role);
            await _repository.AddAsync(employee);
            return employee.Id;
        }
    }
}

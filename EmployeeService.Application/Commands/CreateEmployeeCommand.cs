using MediatR;


namespace EmployeeService.Application.Commands
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
}

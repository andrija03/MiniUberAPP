
namespace EmployeeService.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Role { get; private set; }

        public Employee(string name, string role)
        {
            Id = Guid.NewGuid();
            Name = name;
            Role = role;
        }
    }
}

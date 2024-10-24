using MediatR;

namespace DriverService.Application.Commands
{
    public class RegisterDriverCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string LicenseNumber { get; set; }

        public RegisterDriverCommand(string name, string licenseNumber)
        {
            Name = name;
            LicenseNumber = licenseNumber;
        }
    }
}

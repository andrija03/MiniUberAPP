using DriverService.Application.Commands;
using DriverService.Domain.Entities;
using DriverService.Domain.Repositories;
using MediatR;


namespace DriverService.Application.Handlers
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, Guid>
    {
        private readonly IDriverRepository _repository;

        public CreateDriverCommandHandler(IDriverRepository repository) 
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = new Driver(request.Name, request.Email);
            await _repository.AddAsync(driver);
            return driver.Id;
        }
    }
}


using UserService.Application.Dtos;
using UserService.Application.Messaging;

namespace UserService.Application.Services
{
    public class CreateUserService
    {
        private readonly KafkaProducer _kafkaProducer;

        public CreateUserService(KafkaProducer kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }

        public async Task CreateUserAsync(CreateUserDto userDto)
        {
            var message = $"User created: {userDto.Name}, {userDto.Email}";
            await _kafkaProducer.SendMessageAsync(message);
        }
    }
}

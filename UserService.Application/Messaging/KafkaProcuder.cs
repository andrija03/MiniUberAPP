using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.Messaging
{
    public class KafkaProducer
    {
        private readonly string _kafkaTopic = "user-events";
        private readonly ProducerConfig _producerConfig;

        public KafkaProducer()
        {
            _producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092" // Adresa kafke je definisana u docker-compose.yml
            };
        }

        public async Task SendMessageAsync(string message)
        {
            using var producer = new ProducerBuilder<Null, string>(_producerConfig).Build();
            try
            {
                var result = await producer.ProduceAsync(_kafkaTopic, new Message<Null, string> { Value = message });
                Console.WriteLine($"Message sent to Kafka topic {_kafkaTopic}: {result.Value}");
            }
            catch (ProduceException<Null, string> ex)
            {
                Console.WriteLine($"Error producing message: {ex.Error.Reason}");
            }
        }
    }
}

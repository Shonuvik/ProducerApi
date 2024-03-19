using System;
using System.Text;
using System.Text.Json;
using ProducerFiap.ExternalServices.Interfaces;
using ProducerFiap.Models;
using RabbitMQ.Client;

namespace ProducerFiap.ExternalServices
{
    public class ConnectionFactoryMQ : IConnectionFactoryMQ
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactoryMQ(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public void PublishMessage(User user)
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = _configuration["HostName"],
                UserName = _configuration["User"],
                Password = _configuration["Password"]
            };

            using var connection = connectionFactory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("queue", false, false, false, null);

                var messageToJson = JsonSerializer.Serialize(user);
                var messageToByte = Encoding.UTF8.GetBytes(messageToJson);

                channel.BasicPublish("", "queue", null, messageToByte);
            }
        }
    }
}


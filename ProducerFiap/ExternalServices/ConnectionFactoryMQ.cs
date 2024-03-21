using System;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using ProducerFiap.Config;
using ProducerFiap.ExternalServices.Interfaces;
using ProducerFiap.Models;
using RabbitMQ.Client;

namespace ProducerFiap.ExternalServices
{
    public class ConnectionFactoryMQ : IConnectionFactoryMQ
    {
        private readonly IConfiguration _configuration;
        private readonly MQConfig _mqConfig;

        public ConnectionFactoryMQ(IConfiguration configuration, IOptions<MQConfig> mqConfig)
        {
            _configuration = configuration;
            _mqConfig = mqConfig.Value;
        }

        public void PublishMessage(User user)
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = _mqConfig.HostName,
                UserName = _mqConfig.User,
                Password = _mqConfig.Password
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


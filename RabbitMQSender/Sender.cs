using Newtonsoft.Json;
using RabbitMQ.Client;
using SiteNewsApi.Models.Entities;
using System.Text;

namespace RabbitMQSender
{
    public class Sender
    {
        public static void Send(News news)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(news));

                channel.BasicPublish(exchange: "",
                    routingKey: "hello",
                    basicProperties: properties,
                    body: body);
            }
        }
    }
}

using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SiteNewsApi.Models;
using SiteNewsApi.Models.Entities;
using System;
using System.Linq;
using System.Text;

namespace RabbitMqConsumer
{
    public class Listener
    {
        public void Register()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            }; Console.WriteLine("sent1");

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var _news = JsonConvert.DeserializeObject<News>(Encoding.UTF8.GetString(body));
                    using (var context = new NewsContext())
                    {
                        if (!context.News.Any(j => j.Title.Equals(_news.Title, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            context.News.Add(_news);
                            context.SaveChanges();
                        }
                    }

                    Console.WriteLine(_news.Title);
                };
                channel.BasicConsume(queue: "hello",
                    autoAck: true,
                    consumer: consumer);

                Console.ReadLine();
            }
        }
    }
}

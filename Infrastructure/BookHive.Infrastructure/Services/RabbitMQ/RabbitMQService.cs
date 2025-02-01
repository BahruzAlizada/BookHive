using System.Text;
using System.Threading.Channels;
using BookHive.Application.Abstracts.RabbitMQ;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BookHive.Infrastructure.Services.RabbitMQ
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IConnection connection;
        private readonly IModel chanel;
        public RabbitMQService()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            connection = factory.CreateConnection();
            chanel = connection.CreateModel();
        }
     

        public async Task Publish<T>(string queue, T message)
        {
            await Task.Run(() =>
            {
                chanel.QueueDeclare(queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                chanel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: body);
            });
        }

        public void Subscribe<T>(string queue, Action<T> onMessageReceived)
        {
            throw new NotImplementedException();
        }
    }
}

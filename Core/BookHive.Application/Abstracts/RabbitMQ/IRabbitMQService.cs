
namespace BookHive.Application.Abstracts.RabbitMQ
{
    public interface IRabbitMQService
    {
        Task Publish<T>(string queue, T message);
        void Subscribe<T>(string queue, Action<T> onMessageReceived);
    }
}

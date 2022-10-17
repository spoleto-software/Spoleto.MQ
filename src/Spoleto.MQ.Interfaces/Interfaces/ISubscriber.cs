using System.Threading.Tasks;
using Spoleto.MQ.Messages;

namespace Spoleto.MQ.Interfaces
{
    /// <summary>
    /// Publish/Subscribe pattern https://github.com/EasyNetQ/EasyNetQ/wiki/Publish
    /// </summary>
    public interface ISubscriber
    {
        /// <summary>
        /// Стартует получение сообщений.
        /// </summary>
        void Subscribe();

        /// <summary>
        /// Стартует получение сообщений.
        /// </summary>
        Task SubscribeAsync();
    }

    /// <summary>
    /// Publish/Subscribe pattern https://github.com/EasyNetQ/EasyNetQ/wiki/Publish
    /// </summary>
    public interface ISubscriber<T> : ISubscriber where T : IBaseMessage
    {
        /// <summary>
        /// Событие срабатывает, когда приходит сообщение
        /// </summary>
        event MessageReceived<T> OnMessageReceived;
    }
}
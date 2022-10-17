using System.Threading.Tasks;
using Spoleto.MQ.Messages;

namespace Spoleto.MQ.Interfaces
{
    /// <summary>
    /// Send/Receive pattern https://github.com/EasyNetQ/EasyNetQ/wiki/Send-Receive
    /// </summary>
    public interface IReceiver
    {
        /// <summary>
        /// Стартует получение сообщений.
        /// </summary>
        void Receive();

        /// <summary>
        /// Стартует получение сообщений.
        /// </summary>
        Task ReceiveAsync();
    }

    /// <summary>
    /// Send/Receive pattern https://github.com/EasyNetQ/EasyNetQ/wiki/Send-Receive
    /// </summary>
    public interface IReceiver<T> : IReceiver where T : IUniqueMessage
    {
        /// <summary>
        /// Событие срабатывает, когда приходит сообщение
        /// </summary>
        event UniqueMessageReceived<T> OnMessageReceived;
    }
}
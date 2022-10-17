using System.Threading.Tasks;
using Spoleto.MQ.Messages;

namespace Spoleto.MQ.Interfaces
{
    /// <summary>
    /// Publish/Subscribe pattern https://github.com/EasyNetQ/EasyNetQ/wiki/Publish
    /// </summary>
    public interface IPublisher
    {
        /// <summary>
        /// Publish the message to the MQ.
        /// </summary>
        void Publish<T>(T message) where T : IBaseMessage;

        /// <summary>
        /// Publish the message to the MQ.
        /// </summary>
        Task PublishAsync<T>(T message) where T : IBaseMessage;
    }
}
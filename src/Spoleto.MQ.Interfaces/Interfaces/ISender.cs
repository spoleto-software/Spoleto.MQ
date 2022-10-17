using System.Threading.Tasks;
using Spoleto.MQ.Messages;

namespace Spoleto.MQ.Interfaces
{
    /// <summary>
    /// Send/Receive pattern https://github.com/EasyNetQ/EasyNetQ/wiki/Send-Receive
    /// </summary>
    public interface ISender
    {
        /// <summary>
        /// Send the message to MQ.
        /// </summary>
        void Send<T>(T message) where T : IUniqueMessage;

        /// <summary>
        /// Send the message to MQ.
        /// </summary>
        Task SendAsync<T>(T message) where T : IUniqueMessage;
    }
}
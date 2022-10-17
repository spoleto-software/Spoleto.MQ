using Spoleto.MQ.Messages;

namespace Spoleto.MQ
{
    /// <summary>
    /// Delegate for message received events.
    /// </summary>
    /// <typeparam name="T">The type of message.</typeparam>
    /// <param name="message"></param>
    public delegate void MessageReceived<T>(T message) where T : IBaseMessage;

    /// <summary>
    /// Delegate for unique message received events.
    /// </summary>
    /// <typeparam name="T">The type of message.</typeparam>
    /// <param name="message"></param>
    public delegate void UniqueMessageReceived<T>(T message) where T : IUniqueMessage;
}

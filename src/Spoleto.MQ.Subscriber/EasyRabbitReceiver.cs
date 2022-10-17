using System;
using System.Threading.Tasks;
using Spoleto.MQ;
using Spoleto.MQ.Interfaces;
using Spoleto.MQ.Messages;
using EasyNetQ;

namespace Spoleto.MQ.Subscriber
{
    public class EasyRabbitReceiver<T> : IReceiver<T> where T : IUniqueMessage
    {
        /// <summary>
        /// Событие срабатывает, когда приходит сообщение
        /// </summary>
        public event UniqueMessageReceived<T> OnMessageReceived;

        private readonly IBus _bus;
        private readonly string _uniqueQueueName;

        private IDisposable _receiverResult;

        public EasyRabbitReceiver(IEasyRabbitSubscribeService subscriberService, string uniqueQueueName)
        {
            _bus = subscriberService.Bus;
            _uniqueQueueName = uniqueQueueName;
        }

        /// <summary>
        /// Стартует получение сообщений.
        /// </summary>
        public void Receive()
        {
            _receiverResult = _bus.SendReceive.Receive<T>(_uniqueQueueName, HandleTextMessage);
        }

        public async Task ReceiveAsync()
        {
            _receiverResult = await _bus.SendReceive.ReceiveAsync<T>(_uniqueQueueName, HandleTextMessage).ConfigureAwait(false);
        }

        void HandleTextMessage(T message)
        {
            OnMessageReceived?.Invoke(message);
        }

        internal IDisposable ReceiverResult => _receiverResult;
    }
}

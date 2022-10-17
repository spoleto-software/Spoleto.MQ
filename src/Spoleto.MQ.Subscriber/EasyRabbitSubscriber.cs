using System.Threading.Tasks;
using Spoleto.MQ;
using Spoleto.MQ.Interfaces;
using Spoleto.MQ.Messages;
using EasyNetQ;

namespace Spoleto.MQ.Subscriber
{
    public class EasyRabbitSubscriber<T> : ISubscriber<T> where T : IBaseMessage
    {
        /// <summary>
        /// Событие срабатывает, когда приходит сообщение
        /// </summary>
        public event MessageReceived<T> OnMessageReceived;

        private readonly IBus _bus;
        private readonly string _subscriptionId;
        private readonly string _topic;
        private ISubscriptionResult _subscriptionResult;

        public EasyRabbitSubscriber(IEasyRabbitSubscribeService subscriberService, string subscriptionId, string topic)
        {
            _bus = subscriberService.Bus;
            _subscriptionId = subscriptionId;
            _topic = topic;
        }

        /// <summary>
        /// Стартует получение сообщений.
        /// </summary>
        public void Subscribe()
        {
            if (_topic != null)
            {
                _bus.PubSub.Subscribe<T>(_subscriptionId, HandleTextMessage, x => x.WithTopic(_topic));
            }
            else
            {
                _bus.PubSub.Subscribe<T>(_subscriptionId, HandleTextMessage);
            }
        }

        public async Task SubscribeAsync()
        {
            if (_topic != null)
            {
                await _bus.PubSub.SubscribeAsync<T>(_subscriptionId, HandleTextMessage, x => x.WithTopic(_topic)).ConfigureAwait(false);
            }
            else
            {
                await _bus.PubSub.SubscribeAsync<T>(_subscriptionId, HandleTextMessage).ConfigureAwait(false);
            }
        }

        void HandleTextMessage(T message)
        {
            OnMessageReceived?.Invoke(message);
        }

        internal ISubscriptionResult SubscriptionResult => _subscriptionResult;
    }
}

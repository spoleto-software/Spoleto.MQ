using System;
using System.Collections.Generic;
using Spoleto.MQ.Interfaces;
using Spoleto.MQ.Messages;
using Spoleto.MQ.Options;

namespace Spoleto.MQ.Subscriber
{
    /// <summary>
    /// Менеджер для работы с подписками.
    /// </summary>
    public static class SubscriberManager
    {
        private static readonly Dictionary<Type, ISubscriber> _activeSubscriptions = new Dictionary<Type, ISubscriber>();
        private static readonly Dictionary<string, IReceiver> _activeReceivers = new Dictionary<string, IReceiver>();
        private static IMqOption _settings;
        private static EasyRabbitSubscribeService _subscriberService;

        private static bool _initiliazed = false;
        private static bool _disposed = false;

        public static void Initiliaze(IMqOption settings)
        {
            if (_initiliazed)
                return;

            _settings = settings ?? throw new ArgumentNullException(nameof(IMqOption));
            _subscriberService = new EasyRabbitSubscribeService(_settings);

            _initiliazed = true;
        }

        /// <summary>
        /// Возвращает подписку указанного типа. Далее на событие получения сообщений этой подписки необходимо подписаться <see cref="ISubscriber{T}.OnMessageReceived"/>.
        /// </summary>
        public static ISubscriber<T> GetSubscriber<T>(string subscriptionId, string topic = null) where T : IBaseMessage
        {
            CheckIfInitiliazed();

            if (!_activeSubscriptions.TryGetValue(typeof(T), out var subscriber))
            {
                subscriber = _activeSubscriptions[typeof(T)] = new EasyRabbitSubscriber<T>(_subscriberService, subscriptionId, topic);
                subscriber.Subscribe();
            }

            return (ISubscriber<T>)subscriber;
        }

        /// <summary>
        /// Возвращает подписку указанного типа. Далее на событие получения сообщений этой подписки необходимо подписаться <see cref="ISubscriber{T}.OnMessageReceived"/>.
        /// </summary>
        public static IReceiver<T> GetReceiver<T>(string uniqueQueueName) where T : IUniqueMessage
        {
            CheckIfInitiliazed();

            var key = $"{typeof(T)}_{uniqueQueueName}";

            if (!_activeReceivers.TryGetValue(key, out var receiver))
            {
                receiver = _activeReceivers[key] = new EasyRabbitReceiver<T>(_subscriberService, uniqueQueueName);
                receiver.Receive();
            }

            return (IReceiver<T>)receiver;
        }

        /// <summary>
        /// Полностью отписаться от получения сообщений указанного типа.
        /// </summary>
        public static void Unsubscribe<T>() where T: IBaseMessage
        {
            CheckIfInitiliazed();

            if (_activeSubscriptions.TryGetValue(typeof(T), out var subscriber))
            {
                ((EasyRabbitSubscriber<T>)subscriber).SubscriptionResult.Dispose();
            }
        }

        public static void Dispose()
        {
            if (_initiliazed)
            {
                if (!_disposed)
                {
                    _subscriberService.Bus.Dispose();
                    _disposed = true;
                }
            }
        }

        private static void CheckIfInitiliazed()
        {
            if (!_initiliazed)
                throw new Exception("ServiceManager is not initiliazed. Call the Initialize method first.");
        }
    }
}

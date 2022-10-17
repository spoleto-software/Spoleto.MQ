using EasyNetQ;

namespace Spoleto.MQ.Subscriber
{
    public interface IEasyRabbitSubscribeService
    {
        IBus Bus { get; }
    }
}
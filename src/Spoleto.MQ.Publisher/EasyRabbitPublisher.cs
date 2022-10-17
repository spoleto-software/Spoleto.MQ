using System.Diagnostics;
using System.Threading.Tasks;
using Spoleto.MQ.Interfaces;
using Spoleto.MQ.Messages;
using Spoleto.MQ.Options;
using EasyNetQ;

namespace Spoleto.MQ.Publisher
{
    public class EasyRabbitPublisher : EasyRabbitBase, IPublisher
    {
        public EasyRabbitPublisher(IMqOption settings) : base(settings)
        {
        }

        public void Publish<T>(T message) where T : IBaseMessage
        {
            switch (message)
            {
                case IWithTopicMessage withTopicMessage:
                    Bus.PubSub.Publish(message, withTopicMessage.Topic);
                    break;
                default:
                    Bus.PubSub.Publish(message);
                    break;
            }

            Debug.WriteLine("Message published.");
        }

        public async Task PublishAsync<T>(T message) where T : IBaseMessage
        {
            switch (message)
            {
                case IWithTopicMessage withTopicMessage:
                    await Bus.PubSub.PublishAsync(message, withTopicMessage.Topic).ConfigureAwait(false);
                    break;
                default:
                    await Bus.PubSub.PublishAsync(message).ConfigureAwait(false);
                    break;
            }

            Debug.WriteLine("Message published.");
        }
    }
}

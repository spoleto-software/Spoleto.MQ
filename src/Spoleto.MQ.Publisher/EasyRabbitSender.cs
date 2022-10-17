using System.Diagnostics;
using System.Threading.Tasks;
using Spoleto.MQ.Interfaces;
using Spoleto.MQ.Messages;
using Spoleto.MQ.Options;
using EasyNetQ;

namespace Spoleto.MQ.Publisher
{
    public class EasyRabbitSender : EasyRabbitBase, ISender
    {
        public EasyRabbitSender(IMqOption settings) : base(settings)
        {
        }

        public void Send<T>(T message) where T : IUniqueMessage
        {
            var uniqueQueueName = message.UniqueName;
            Bus.SendReceive.Send(uniqueQueueName, message);

            Debug.WriteLine("Message sent.");
        }

        public async Task SendAsync<T>(T message) where T : IUniqueMessage
        {
            var uniqueQueueName = message.UniqueName;
            await Bus.SendReceive.SendAsync(uniqueQueueName, message).ConfigureAwait(false);

            Debug.WriteLine("Message sent.");
        }
    }
}

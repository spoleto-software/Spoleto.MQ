using System;

namespace Spoleto.MQ.Messages
{
    public interface IBaseMessage
    {
        DateTime? Timestamp { get; set; }
    }
}

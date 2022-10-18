using System;

namespace Spoleto.MQ.Messages
{
    /// <summary>
    /// The base base.
    /// </summary>
    public interface IBaseMessage
    {
        /// <summary>
        /// Gets or sets the message timestamp.
        /// </summary>
        DateTime? Timestamp { get; set; }
    }
}

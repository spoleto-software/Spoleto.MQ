namespace Spoleto.MQ.Messages
{
    /// <summary>
    /// The message with the unique queue name.<br/>
    /// Used in Send-Receive pattern:<br/>
    /// <see cref="Interfaces.ISender"/> - <see cref="Interfaces.IReceiver{T}"/>.
    /// </summary>
    public interface IUniqueMessage : IBaseMessage
    {
        /// <summary>
        /// Gets or sets the unique queue name.
        /// </summary>
        string UniqueName { get; }
    }
}

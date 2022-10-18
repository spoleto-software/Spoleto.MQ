namespace Spoleto.MQ.Messages
{
    /// <summary>
    /// The message with the topic.
    /// </summary>
    public interface IWithTopicMessage
    {
        /// <summary>
        /// Gets or sets the topic name.
        /// </summary>
        string Topic { get; }
    }
}

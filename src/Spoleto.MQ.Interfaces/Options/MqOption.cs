namespace Spoleto.MQ.Options
{
    /// <summary>
    /// The MQ options.
    /// </summary>
    public class MqOption : IMqOption
    {
        /// <summary>
        /// Gets or sets the host url.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets Rabbit MQ username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets password for Rabbit MQ user.
        /// </summary>
        public string Password { get; set; }
    }
}

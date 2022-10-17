namespace Spoleto.MQ.Options
{
    /// <summary>
    /// The MQ options.
    /// </summary>
    public interface IMqOption
    {
        /// <summary>
        /// Gets or sets the host url.
        /// </summary>
        string Host { get; set; }

        /// <summary>
        /// Gets or sets Rabbit MQ username.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets password for Rabbit MQ user.
        /// </summary>
        string Password { get; set; }
    }
}
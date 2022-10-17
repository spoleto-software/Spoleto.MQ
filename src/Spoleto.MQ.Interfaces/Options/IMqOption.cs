namespace Spoleto.MQ.Options
{
    /// <summary>
    /// The MQ options.
    /// </summary>
    public interface IMqOption
    {
        string Host { get; set; }

        string Username { get; set; }

        string Password { get; set; }
    }
}
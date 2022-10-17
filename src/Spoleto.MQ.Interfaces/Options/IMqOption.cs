namespace Spoleto.MQ.Options
{
    public interface IMqOption
    {
        string Host { get; set; }

        string Username { get; set; }

        string Password { get; set; }
    }
}
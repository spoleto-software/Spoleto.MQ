namespace Spoleto.MQ.Messages
{
    public interface IUniqueMessage : IBaseMessage
    {
        string UniqueName { get; }
    }
}

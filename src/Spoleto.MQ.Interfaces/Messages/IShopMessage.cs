using System;

namespace Spoleto.MQ.Messages
{
    public interface IShopMessage : IBaseMessage
    {
        Guid ShopId { get; set; }
    }
}

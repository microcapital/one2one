using MediatR;
using OneTwoOne.Module.Orders.Models;

namespace OneTwoOne.Module.Orders.Events
{
    public class OrderCreated : INotification
    {
        public long OrderId { get; set; }

        public Order Order { get; set; }

        public long UserId { get; set; }

        public string Note { get; set; }
    }
}

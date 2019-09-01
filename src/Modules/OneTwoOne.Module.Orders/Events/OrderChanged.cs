﻿using MediatR;
using OneTwoOne.Module.Orders.Models;

namespace OneTwoOne.Module.Orders.Events
{
    public class OrderChanged : INotification
    {
        public long OrderId { get; set; }

        public Order Order { get; set; }

        public OrderStatus? OldStatus { get; set; }

        public OrderStatus NewStatus { get; set; }

        public long UserId { get; set; }

        public string Note { get; set; }
    }
}
